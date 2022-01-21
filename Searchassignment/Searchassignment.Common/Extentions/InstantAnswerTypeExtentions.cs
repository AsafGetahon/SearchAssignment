using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Searchassignment.Model.Enum;

namespace Searchassignment.Common.Extentions
{
    public class InstantAnswerTypeExtentions : JsonConverter
    {
        public override bool CanConvert(Type objectType)
    => objectType == typeof(InstantAnswerTypeEnum);

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            switch ((string)reader.Value)
            {
                case "A":
                    return InstantAnswerTypeEnum.Article;
                case "D":
                    return InstantAnswerTypeEnum.Disambiguation;
                case "C":
                    return InstantAnswerTypeEnum.Category;
                case "N":
                    return InstantAnswerTypeEnum.Name;
                case "E":
                    return InstantAnswerTypeEnum.Exclusive;
                default:
                    return InstantAnswerTypeEnum.None;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
