using RestSharp;
using SonarQubeApiCSharp.Entities;
using SonarQubeApiCSharp.Helpers;
using SonarQubeApiCSharp.Workers;
using System.Collections.Generic;

namespace SonarQubeApiCSharp.Api
{
    public class Permissions
    {
        //private static string PERMISSIONS_ADDGROUP_ID = "/api/permissions/add_group?projectId={0}&groupId={1}&permission={2}";
        //private static string PERMISSIONS_REMOVEGROUP_KEY = "/api/permissions/remove_group?projectKey={0}&groupId={1}&permission={2}";
        private static string PERMISSIONS_ADDGROUP_KEY = "/api/permissions/add_group?projectKey={0}&groupId={1}&permission={2}";

        private ImprovedRestClient _client;

        internal Permissions(ImprovedRestClient client)
        {
            _client = client;
        }

        /*public Project AddGroup(int ProjectId, int GroupId, EProjectPermission permission)
        {
            var url = UrlBuilder.FormatRestApiUrl(PERMISSIONS_ADDGROUP_ID, ProjectId.ToString(), GroupId.ToString(), permission.ToString());
            var request = new RestRequest(url, Method.POST);
            Project response = _client.Execute<Project>(request);
            return response;
        }*/

        public void AddGroup(string ProjectKey, int GroupId, EProjectPermission permission)
        {
            var url = UrlBuilder.FormatRestApiUrl(PERMISSIONS_ADDGROUP_KEY, ProjectKey, GroupId.ToString(), permission.ToString());
            var request = new RestRequest(url, Method.POST);
            Project response = _client.Execute<Project>(request);
        }
    }

    public enum EProjectPermission
    {
        user,
        admin,
        issueadmin,
        codeviewer
    }
}
