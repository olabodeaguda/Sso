using Business360.sso.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Core.Interfaces.Repositories
{
    public interface IApiResourceRepository
    {
        Task<ApiResourceModel> CreateApiResource(ApiResourceModel model);
        Task<ApiResourceModel> UpdateApiResource(ApiResourceModel model);

        Task<ApiResourceModel> ActivateApiResource(string resourceName);
        Task<ApiResourceModel> DeactivateApiResource(string resourceName);

        Task<ApiResourceModel> Get(string resourceName);
    }
}
