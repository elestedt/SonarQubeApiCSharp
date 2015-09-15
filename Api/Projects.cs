using RestSharp;
using SonarQubeApiCSharp.Entities;
using SonarQubeApiCSharp.Workers;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Api
{
    public class Projects
    {
        private static string RESOURCES = "/api/resources";

        private ImprovedRestClient _client;

        internal Projects(ImprovedRestClient client)
        {
            _client = client;
        }

        public List<Project> Get()
        {
            var request = new RestRequest(RESOURCES, Method.GET);
            List<Project> response = _client.Execute<List<Project>>(request);
            return response;
        }
    }
}
