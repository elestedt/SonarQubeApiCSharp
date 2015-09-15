using Newtonsoft.Json;
using RestSharp;
using SonarQubeApiCSharp.Helpers;
using SonarQubeApiCSharp.Workers;

namespace SonarQubeApiCSharp.Api
{
    public class Groups
    {
        private static string USERGROUPS_SEARCH = "/api/usergroups/search";
        private static string USERGROUPS_SEARCH_QUERY = "/api/usergroups/search?q={0}";
        private static string USERGROUPS_CREATE = "/api/usergroups/create?name={0}";

        private ImprovedRestClient _client;

        internal Groups(ImprovedRestClient client)
        {
            _client = client;
        }

        public Entities.Groups Get()
        {
            var request = new RestRequest(USERGROUPS_SEARCH, Method.GET);
            Entities.Groups response = _client.Execute<Entities.Groups>(request);
            return response;
        }

        public Entities.Groups Get(string query)
        {
            var url = UrlBuilder.FormatRestApiUrl(USERGROUPS_SEARCH_QUERY, query);
            var request = new RestRequest(url, Method.GET);
            Entities.Groups response = _client.Execute<Entities.Groups>(request);
            return response;
        }

        internal class CreateGroupResponseWrapper
        {
            [JsonProperty("group")]
            public Entities.Group Group { get; set; }
        }

        public Entities.Group Create(string name)
        {
            var url = UrlBuilder.FormatRestApiUrl(USERGROUPS_CREATE, name);
            var request = new RestRequest(url, Method.POST);
            var response = _client.Execute<CreateGroupResponseWrapper>(request);
            return response.Group;
        }
    }
}
