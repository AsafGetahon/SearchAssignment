using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Model.DTO
{
    [JsonObject("RelatedTopicsSection")]
    public class DTORelatedTopicSection
    {
        public string Name { get; set; }

        public DTOTopic[] Topics { get; set; }
    }
}
