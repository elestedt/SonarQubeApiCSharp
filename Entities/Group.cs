using Newtonsoft.Json;
using SonarQubeApiCSharp.Helpers;
using System;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Entities
{
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("membersCount")]
        public int MembersCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Groups: ResponseWrapper
    {
        [JsonProperty("groups")]
        public IEnumerable<Group> Values { get; set; }

    }
}
