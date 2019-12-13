using Business360.sso.Core.Interfaces.Repositories;
using Business360.sso.Core.Models;
using Business360.sso.Data.Entities;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Data.Repositories
{
    public class ApiResourceRepository : IApiResourceRepository
    {
        private readonly IResourceStore _resourceStore;
        private readonly DbContext _dbContext;
        public ApiResourceRepository(DbContext dbContext, IResourceStore resourceStore)
        {
            _resourceStore = resourceStore;
            _dbContext = dbContext;
        }

        public async Task<ApiResourceModel> CreateApiResource(ApiResourceModel model)
        {
            return null;
        }

        public async Task<ApiResourceModel> ActivateApiResource(string resourceName)
        {
            return null;
        }

        public async Task<ApiResourceModel> DeactivateApiResource(string resourceName)
        {
            return null;
        }

        public async Task<ApiResourceModel> UpdateApiResource(ApiResourceModel model)
        {
            return null;
        }

        public async Task<ApiResourceModel> Get(string resourceName)
        {
            return null;
        }
    }
}
