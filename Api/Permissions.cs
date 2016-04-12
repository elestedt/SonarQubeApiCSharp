using RestSharp;
using SonarQubeApiCSharp.Entities;
using SonarQubeApiCSharp.Helpers;
using SonarQubeApiCSharp.Workers;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Api
{
    public class Permissions
    {
        private static string PERMISSIONS_ADDUSER_KEY = "/api/permissions/add_user?projectKey={0}&login={1}&permission={2}";
        private static string PERMISSIONS_ADDGROUP_KEY = "/api/permissions/add_group?projectKey={0}&groupName={1}&permission={2}";

        private ImprovedRestClient _client;

        internal Permissions(ImprovedRestClient client)
        {
            _client = client;
        }

        public void AddGroup(string ProjectKey, string GroupName, EProjectPermission permission)
        {
            var url = UrlBuilder.FormatRestApiUrl(PERMISSIONS_ADDGROUP_KEY, ProjectKey, GroupName, permission.ToString());
            var request = new RestRequest(url, Method.POST);
            Project response = _client.Execute<Project>(request);
        }

        public void AddUser(string ProjectKey, string login, EProjectPermission permission)
        {
            var url = UrlBuilder.FormatRestApiUrl(PERMISSIONS_ADDUSER_KEY, ProjectKey, login, permission.ToString());
            var request = new RestRequest(url, Method.POST);
            Project response = _client.Execute<Project>(request);
        }
    }

    public enum EProjectPermission
    {
        user,
        scan,
        admin,
        issueadmin,
        codeviewer
    }
}
