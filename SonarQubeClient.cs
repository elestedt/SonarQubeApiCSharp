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
            this.Groups = new Groups(_client);
            this.Permissions = new Permissions(_client);
        }

        public Projects Projects { get; private set; }

        public Groups Groups { get; private set; }

        public Permissions Permissions { get; private set; }
    }
}
