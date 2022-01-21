using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Model.DTO
{
    [JsonObject("RelatedTopic")]
    public class DTORelatedTopics
    {
        public DTOTopic Topic { get; }

        public DTORelatedTopicSection RelatedTopicSection { get; }

        public DTORelatedTopics(DTOTopic topic)
        {
            Topic = topic;
        }

        public DTORelatedTopics(DTORelatedTopicSection relatedTopicSection)
        {
            RelatedTopicSection = relatedTopicSection;
        }
    }
}
