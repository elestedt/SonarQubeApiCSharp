using RestSharp;
using SonarQubeApiCSharp.Entities;
using SonarQubeApiCSharp.Helpers;
using SonarQubeApiCSharp.Workers;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Api
{
    public class Projects
    {
        private static string PROJECTS_LIST = "/api/projects/list";
        private static string PROJECTS_LIST_QUERY = "/api/projects/list?key={0}";
        private static string PROJECTS_CREATE = "/api/projects/create?key={0}&name={1}";

        private ImprovedRestClient _client;

        internal Projects(ImprovedRestClient client)
        {
            _client = client;
        }

        public List<Project> Get()
        {
            var request = new RestRequest(PROJECTS_LIST, Method.GET);
            List<Project> response = _client.Execute<List<Project>>(request);
            return response;
        }

        public List<Project> Get(string key)
        {
            var url = UrlBuilder.FormatRestApiUrl(PROJECTS_LIST_QUERY, key);
            var request = new RestRequest(url, Method.GET);
            List<Project> response = _client.Execute<List<Project>>(request);
            return response;
        }

        public Project Create(string key, string name)
        {
            var url = UrlBuilder.FormatRestApiUrl(PROJECTS_CREATE, key, name);
            var request = new RestRequest(url, Method.POST);
            Project response = _client.Execute<Project>(request);
            return response;

        }
    }
}
