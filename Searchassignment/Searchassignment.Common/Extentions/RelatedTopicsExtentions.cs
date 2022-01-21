using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Searchassignment.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Common.Extentions
{
    public class RelatedTopicsExtentions : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(DTORelatedTopics);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            return jObject
                .Properties()
                .Any(p => p.Name == "Result")
                ? new DTORelatedTopics(jObject.ToObject<DTOTopic>())
                : new DTORelatedTopics(jObject.ToObject<DTORelatedTopicSection>());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
