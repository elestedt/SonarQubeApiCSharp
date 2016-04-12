using Newtonsoft.Json;
using SonarQubeApiCSharp.Helpers;
using System;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Entities
{
    public class User
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string EMail { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("local")]
        public bool Local { get; set; }

        [JsonProperty("externalIdentity")]
        public string ExternalIdentity { get; set; }

        [JsonProperty("externalProvider")]
        public string ExternalProvider { get; set; }

        [JsonProperty("groups")]
        public List<string> Groups { get; set; }

        [JsonProperty("scmAccounts")]
        public List<string> SCMAccounts { get; set; }

        [JsonProperty("tokensCount")]
        public uint tokensCount { get; set; }
    }

    public class Users: ResponseWrapper
    {
        [JsonProperty("users")]
        public IEnumerable<User> Values { get; set; }

    }
}
