using SonarQubeApiCSharp.Workers;

namespace SonarQubeApiCSharp.Api
{
    public class Projects
    {
        private ImprovedRestClient _client;

        internal Projects(ImprovedRestClient client)
        {
            _client = client;
        }
    }
}
