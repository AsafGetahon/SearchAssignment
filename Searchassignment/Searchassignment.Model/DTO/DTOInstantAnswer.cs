using Newtonsoft.Json;
using Searchassignment.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Model.DTO
{
    public class DTOInstantAnswer
    {
        [JsonProperty("RelatedTopics")]
        public DTORelatedTopics[] InternalRelatedTopics { get; set; }
        public InstantAnswerTypeEnum Type { get; set; }
        public string Abstract { get; set; }
        public string AbstractText { get; set; }
        public string AbstractSource { get; set; }
        [JsonProperty("AbstractURL")]
        public string AbstractUrl { get; set; }

        [JsonProperty("Image")]
        public string ImageUrl { get; set; }
        public string Heading { get; set; }
        public string Answer { get; set; }
        public string AnswerType { get; set; }
        public string Definition { get; set; }
        public string DefinitionSource { get; set; }

        [JsonProperty("DefinitionUrl")]
        public string DefinitionUrl { get; set; }

        public string Entity { get; set; }

        public DTOTopic[] Results { get; set; }

        [JsonIgnore]
        public DTOTopic[] RelatedTopics =>
            InternalRelatedTopics
                .Where(r => r.Topic != null)
                .Select(r => r.Topic)
                .ToArray();

        [JsonIgnore]
        public DTORelatedTopicSection[] RelatedTopicSection =>
            InternalRelatedTopics
                .Where(r => r.RelatedTopicSection != null)
                .Select(r => r.RelatedTopicSection)
                .ToArray();

        [JsonProperty("RedirectURL")]
        public string RedirectUrl { get; set; }
    }
}
