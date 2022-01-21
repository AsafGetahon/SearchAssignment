using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Model.DTO
{
    [JsonObject("RelatedTopic")]
    public class DTOTopic
    {
        [JsonProperty("Result")]
        public string ResultText { get; set; }

        [JsonProperty("FirstURL")]
        public string FirstUrl { get; set; }

        public DTOIcon Icon { get; set; }

        public string Text { get; set; }
    }
}
