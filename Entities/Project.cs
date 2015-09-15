using Newtonsoft.Json;
using System;

namespace SonarQubeApiCSharp.Entities
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("k")]
        public string Key { get; set; }

        [JsonProperty("nm")]
        public string Name { get; set; }

    }

}
