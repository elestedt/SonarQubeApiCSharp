using SonarQubeApiCSharp.Api;
using SonarQubeApiCSharp.Workers;
using RestSharp;
using RestSharp.Authenticators;

namespace SonarQubeApiCSharp
{
    public class SonarQubeClient
    {
        private ImprovedRestClient _client;

        public SonarQubeClient(string baseUrl, string username, string password)
        {
            _client = new ImprovedRestClient(baseUrl, username, password);
            InjectDependencies();
        }

        private void InjectDependencies()
        {
            this.Projects = new Projects(_client);
        }

        public Projects Projects { get; private set; }
    }
}
