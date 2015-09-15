using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text;

namespace SonarQubeApiCSharp.Workers
{
    class ImprovedRestClient
    {
        private RestClient _client;

        public ImprovedRestClient(string baseUrl, string username, string password)
        {
            _client = new RestClient(baseUrl);
            _client.Authenticator = new HttpBasicAuthenticator(username, password);
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var response = _client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.StatusCode != System.Net.HttpStatusCode.OK ? default(T) : response.Data;
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public T Execute<T, Y>(RestRequest request, Y param) where Y : new() where T : new()
        {
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.RequestFormat = DataFormat.Json;
            if (param != null)
                request.AddJsonBody(param);
            var response = _client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Content.Contains("errors: [") ? default(T) : response.Data;
        }

        public bool Execute<Y>(RestRequest request, Y param) where Y : new()
        {
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.RequestFormat = DataFormat.Json;
            
            if (param != null)
            {
                var data = JsonConvert.SerializeObject(param, Formatting.Indented);
                request.AddParameter("application/json", data, null, ParameterType.RequestBody);
            }
            var response = _client.Execute(request);
            return (response.ErrorException == null);
        }
    }
}
