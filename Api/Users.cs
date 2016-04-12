using Newtonsoft.Json;
using RestSharp;
using SonarQubeApiCSharp.Helpers;
using SonarQubeApiCSharp.Workers;

namespace SonarQubeApiCSharp.Api
{
    public class Users
    {
        private static string USER_CREATE = "/api/users/create?email={0}&login={1}&name={2}&&password={3}";

        private ImprovedRestClient _client;

        internal Users(ImprovedRestClient client)
        {
            _client = client;
        }

        public Entities.User Create(string ProjectKey, string Password)
        {
            var user = new Entities.User
            {
                Login = $"{ProjectKey.ToLower()}-user",
                Name = $"{ProjectKey} Project User",
                EMail = "no-reply@volvocars.com",
                Active = true,
                Local = true,
                ExternalIdentity = $"{ProjectKey}-user",
                ExternalProvider = "sonarqube",
                Groups = new System.Collections.Generic.List<string>(),
                SCMAccounts = new System.Collections.Generic.List<string>(),
                tokensCount = 0,
            };
            var url = UrlBuilder.FormatRestApiUrl(USER_CREATE, "no-reply@volvocars.com", $"{ProjectKey.ToLower()}-user", $"{ProjectKey} Project User", Password);
            var request = new RestRequest(url, Method.POST);
            var response = _client.Execute<Entities.User>(request, null);
            return response ? user : null;
        }
    }
}
