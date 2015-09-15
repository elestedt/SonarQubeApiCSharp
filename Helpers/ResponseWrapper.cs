using Newtonsoft.Json;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Helpers
{
    public class ResponseWrapper
    {
        [JsonProperty("p")]
        public int Page { get; set; }
        [JsonProperty("ps")]
        public int PageSize { get; set; }
        [JsonProperty("total")]
        public int Pages { get; set; }
    }
}
