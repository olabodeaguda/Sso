using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business360.sso.Data.Repositories
{
    public class ResourceStore : IResourceStore
    {
        private readonly APPDbContext _context;
        private readonly ILogger _logger;

        public ResourceStore(APPDbContext context)
        {
            _context = context;
        }

        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            var apiResource = _context.ApiResources.First(t => t.ApiResourceName == name);
            //apiResource.MapDataFromEntity();
            return Task.FromResult(apiResource.ApiResourceData.ToObjectJsonString<ApiResource>());
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));


            var apiResources = new List<ApiResource>();
            var apiResourcesEntities = from i in _context.ApiResources
                                       where scopeNames.Contains(i.ApiResourceName)
                                       select i;

            foreach (var apiResourceEntity in apiResourcesEntities)
            {
                apiResources.Add(apiResourceEntity.ApiResourceData.ToObjectJsonString<ApiResource>());
            }

            return Task.FromResult(apiResources.AsEnumerable());
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null) throw new ArgumentNullException(nameof(scopeNames));

            var identityResources = new List<IdentityResource>();
            var identityResourcesEntities = from i in _context.IdentityResources
                                            where scopeNames.Contains(i.IdentityResourceName)
                                            select i;

            foreach (var identityResourceEntity in identityResourcesEntities)
            {
                identityResources.Add(identityResourceEntity.IdentityResourceData.ToObjectJsonString<IdentityResource>());
            }

            return Task.FromResult(identityResources.AsEnumerable());
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            var apiResourcesEntities = _context.ApiResources.ToList();
            var identityResourcesEntities = _context.IdentityResources.ToList();

            var apiResources = new List<ApiResource>();
            var identityResources = new List<IdentityResource>();

            foreach (var apiResourceEntity in apiResourcesEntities)
            {
                apiResources.Add(apiResourceEntity.ApiResourceData.ToObjectJsonString<ApiResource>());
            }

            foreach (var identityResourceEntity in identityResourcesEntities)
            {
                identityResources.Add(identityResourceEntity.IdentityResourceData.ToObjectJsonString<IdentityResource>());
            }

            var result = new Resources(identityResources, apiResources);
            return Task.FromResult(result);
        }
    }
}
