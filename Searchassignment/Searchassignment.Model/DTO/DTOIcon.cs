using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Model.DTO
{
    public class DTOIcon
    {
        [JsonProperty("URL")]
        public string Url { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }
    }
}
