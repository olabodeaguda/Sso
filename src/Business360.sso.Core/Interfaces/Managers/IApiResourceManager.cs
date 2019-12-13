using Business360.sso.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Core.Interfaces.Managers
{
    public interface IApiResourceManager
    {
        Task<ApiResourceModel> Get(string resourcename);
        Task<ApiResourceModel> CreateApiResource(ApiResourceModel model);
        Task<ApiResourceModel> ActivateApiResource(string resourceName);
        Task<ApiResourceModel> DeactivateApiResource(string resourceName);


        Task<ApiResourceModel> CreateScope(string resourceName, string scopeName, string scopeDisplayName);
        Task<ApiResourceModel> RemoveScope(string resourceName, string scopeName);


        Task<ApiResourceModel> CreateClaims(string resourceName, string claimType);
        Task<ApiResourceModel> RemoveClaims(string resourceName, string scopeName);
    }
}
