using Business360.sso.Core.Exceptions;
using Business360.sso.Core.Interfaces.Managers;
using Business360.sso.Core.Interfaces.Repositories;
using Business360.sso.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Core.Managers
{
    public class ApiResourceManager : IApiResourceManager
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        public ApiResourceManager(IApiResourceRepository apiResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
        }

        public async Task<ApiResourceModel> ActivateApiResource(string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
                throw new BadRequestException("Resource name is required");

            var result = await _apiResourceRepository.ActivateApiResource(resourceName);

            if (result == null)
                throw new BadRequestException("Activation failed");

            return result;
        }

        public async Task<ApiResourceModel> CreateApiResource(ApiResourceModel model)
        {
            var result = await _apiResourceRepository.CreateApiResource(model);

            return result;
        }

        public async Task<ApiResourceModel> CreateClaims(string resourceName, string claimType)
        {
            var model = await _apiResourceRepository.Get(resourceName);
            if (model == null)
                throw new BadRequestException("Resource can not be found");

            var claims = model.UserClaims ?? new string[] { };

            if (claims.Any(x => x == claimType))
                throw new AlreadyExistException("Claim already exist");

            model.UserClaims = claims.Concat(new string[] { claimType }).ToArray();

            var result = await _apiResourceRepository.UpdateApiResource(model);
            return result;
        }

        public async Task<ApiResourceModel> CreateScope(string resourceName, string scopeName, string scopeDisplayName)
        {
            var model = await _apiResourceRepository.Get(resourceName);
            if (model == null)
                throw new BadRequestException("Resource can not be found");

            var scopes = model.Scopes ?? new ScopeModel[] { };

            if (scopes.Any(x => x.Name == scopeName))
                throw new AlreadyExistException("Scope already exist");

            model.Scopes = scopes.Concat(new ScopeModel[] { new ScopeModel
            {
                Name=scopeName,
                 DisplayName = scopeDisplayName
            }
            }).ToArray();

            var result = await _apiResourceRepository.UpdateApiResource(model);
            return result;
        }

        public async Task<ApiResourceModel> DeactivateApiResource(string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
                throw new BadRequestException("Resource name is required");

            var result = await _apiResourceRepository.DeactivateApiResource(resourceName);

            if (result == null)
                throw new BadRequestException("Deactivation failed");

            return result;
        }

        public async Task<ApiResourceModel> Get(string resourcename)
        {
            var result = await _apiResourceRepository.Get(resourcename);

            if (result == null)
                throw new BadRequestException($"{resourcename} does not exist");

            return result;
        }

        public async Task<ApiResourceModel> RemoveClaims(string resourceName, string claimType)
        {
            var model = await _apiResourceRepository.Get(resourceName);
            if (model == null)
                throw new BadRequestException("Resource can not be found");

            var claims = model.UserClaims;

            if (!claims.Any(x => x == claimType))
                throw new AlreadyExistException("Claim does not exist");

            model.UserClaims = claims.Where(x => x != claimType).ToArray();

            var result = await _apiResourceRepository.UpdateApiResource(model);
            return result;
        }

        public async Task<ApiResourceModel> RemoveScope(string resourceName, string scopeName)
        {
            var model = await _apiResourceRepository.Get(resourceName);
            if (model == null)
                throw new BadRequestException("Resource can not be found");

            var scopes = model.Scopes;

            if (!scopes.Any(x => x.Name == scopeName))
                throw new AlreadyExistException("Scope does not exist");

            model.Scopes = scopes.Where(x => x.Name != scopeName).ToArray();

            var result = await _apiResourceRepository.UpdateApiResource(model);
            return result;
        }
    }
}
