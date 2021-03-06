using Searchassignment.Dal.Entities;
using Searchassignment.Model.DTO;
using Searchassignment.Common.Extentions;

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Searchassignment.Dal.Repositories;
using DuckSharp;
using System.Net.Http;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;

namespace Searchassignment.Service.Services
{
    public interface IQueryService : IGenericDataService<DTOQuery, QueryEntity>
    {
        Task<IEnumerable<QueryEntity>> GetAllQuery();
        Task<List<DTOTopic>> GetQueryResultsAsync(string query);
    }
    public class QueryService : GenericDataService<DTOQuery, QueryEntity>, IQueryService
    {
        private readonly IConfiguration _configuration;
        private readonly DuckSharpClient _client = new DuckSharpClient();
        protected static HttpClient HttpClient;
        private readonly bool _allowDisambiguation;
        private readonly bool _allowHtml;
        private readonly string _applicationName;
        private readonly DbEntity _dbContext;

        public QueryService(IMapper mapper, IQueryRepository repository, IConfiguration configuration, DbEntity dbContext, string applicationName = "Searchassignment", 
                bool allowHtml = true, bool allowDisambiguation = true, HttpClient client = null) : base(mapper, repository)
        {
            _applicationName = applicationName;
            _allowHtml = allowHtml;
            _allowDisambiguation = allowDisambiguation;
            _dbContext = dbContext;
            _configuration = configuration;
            HttpClient defaultClient = HttpClient ?? new HttpClient();
            HttpClient = client ?? defaultClient;
        }

        public async Task<List<DTOTopic>> GetQueryResultsAsync(string query)
        {
            var response = new List<DTOTopic>();
            var results = GetInstantAnswerAsync(query).Result;
            foreach (var topic in results.InternalRelatedTopics)
            {
                response.Add(topic.Topic);
            }
            _repository.Add(new QueryEntity { QuerySearched = query });
            return response;
        }

        public async Task<DTOInstantAnswer> GetInstantAnswerAsync(string query, CancellationToken token = default) =>
            JsonConvert.DeserializeObject<DTOInstantAnswer>(
                await GetApiResponse(query, token)
                   .ConfigureAwait(false),
                new InstantAnswerTypeExtentions(),
                new RelatedTopicsExtentions());

        public async Task<string> GetBangRedirectAsync(string query, CancellationToken token = default)
    => (await GetInstantAnswerAsync(query, token)
           .ConfigureAwait(false))
       .RedirectUrl;

        private async Task<string> GetApiResponse(string query, CancellationToken token = default)
        {
            Uri uri = BuildUri(query);
            return await GetResponse(uri, token)
               .ConfigureAwait(false);
        }

        private Uri BuildUri(string query)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                ["q"] = query,
                ["q"] = query,
                ["format"] = "json",
                ["t"] = _applicationName,
                ["no_redirect"] = 1.ToString(),
                ["no_html"] = (!_allowHtml ? 1 : 0).ToString(),
                ["skip_disambig"] = (!_allowDisambiguation ? 1 : 0).ToString(),
                ["pretty"] = 1.ToString()
            };

            var queryBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                queryBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}&", pair.Key, pair.Value);
            }

            var builder = new UriBuilder("https://api.duckduckgo.com")
            {
                Query = queryBuilder.ToString()
            };
            return builder.Uri;
        }

        private static async Task<string> GetResponse(Uri uri, CancellationToken token)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(uri, token)
               .ConfigureAwait(false);
            using (response)
            {
                return await response.Content.ReadAsStringAsync()
                   .ConfigureAwait(false);
            }
        }

        public async Task<IEnumerable<QueryEntity>> GetAllQuery()
        {
            return _dbContext.SearchQuery.ToList();
        }
    }
}
