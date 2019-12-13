using Business360.sso.Core.Exceptions;
using Business360.sso.Core.Interfaces;
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
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository _clientRepository;
        public ClientManager(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientModel> Create(ClientModel client)
        {
            var itExist = await _clientRepository.FindClientByIdAsync(client.ClientId);
            if (itExist != null)
                throw new AlreadyExistException("Client already exist");

            var result = await _clientRepository.CreateClient(client);

            if (result == null)
                throw new BadRequestException("Request failed. Please try again or contact your adminsitrator for help");

            return client;
        }

        public async Task<ClientModel> Get(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new BadRequestException("Client is required");

            var client = await _clientRepository.FindClientByIdAsync(clientId);
            if (client == null)
                throw new NotFoundException("Client does not exist");
            return client;
        }

        public async Task<ClientModel> AddAllowUri(string clietId, string url)
        {
            var result = await _clientRepository.FindClientByIdAsync(clietId);

            if (result == null)
                throw new NotFoundException("Client can not be found");

            var uri = result.AllowedCorsOrigins;
            if (uri.Length > 0)
            {
                var itExist = uri.FirstOrDefault(x => x == url);
                if (itExist != null)
                    throw new AlreadyExistException($"{url}  already exist");
            }

            result.AllowedCorsOrigins = uri.Concat(new string[] { url }).ToArray();

            var res = await _clientRepository.UpdateClient(result);
            if (res == null)
                throw new BadRequestException("Update failed");

            return res;
        }

        public async Task<ClientModel> RemoveAllowUri(string clietId, string url)
        {
            var result = await _clientRepository.FindClientByIdAsync(clietId);

            if (result == null)
                throw new NotFoundException("Client can not be found");

            var uri = result.AllowedCorsOrigins;
            if (uri.Length <= 0)
            {
                throw new BadRequestException($"{url} does not exist");
            }
            var itExist = uri.FirstOrDefault(x => x == url);
            if (itExist == null)
            {
                throw new BadRequestException($"{url} does not exist");
            }
            uri = uri.Where(x => x != url).ToArray();


            result.AllowedCorsOrigins = uri;

            var res = await _clientRepository.UpdateClient(result);
            if (res == null)
                throw new BadRequestException("Update failed");

            return res;
        }

        public async Task<ClientModel> AddAllowedScope(string clietId, string scope)
        {
            var result = await _clientRepository.FindClientByIdAsync(clietId);

            if (result == null)
                throw new NotFoundException("Client can not be found");

            var scopes = result.AllowedScopes;
            if (scopes.Length > 0)
            {
                var itExist = scopes.FirstOrDefault(x => x == scope);
                if (itExist != null)
                    throw new AlreadyExistException($"{scope}  already exist");
            }

            result.AllowedScopes = scopes.Concat(new string[] { scope }).ToArray();

            var res = await _clientRepository.UpdateClient(result);
            if (res == null)
                throw new BadRequestException("Update failed");

            return res;
        }

        public async Task<ClientModel> RemoveAllowedScope(string clietId, string scope)
        {
            var result = await _clientRepository.FindClientByIdAsync(clietId);

            if (result == null)
                throw new NotFoundException("Client can not be found");

            var scopes = result.AllowedScopes;
            if (scopes.Length <= 0)
            {
                throw new BadRequestException($"{scope} does not exist");
            }
            var itExist = scopes.FirstOrDefault(x => x == scope);
            if (itExist == null)
            {
                throw new BadRequestException($"{scope} does not exist");
            }
            scopes = scopes.Where(x => x != scope).ToArray();


            result.AllowedScopes = scopes;

            var res = await _clientRepository.UpdateClient(result);
            if (res == null)
                throw new BadRequestException("Update failed");

            return res;
        }

        public async Task<ClientModel> AddAllowedGrantType(string clietId, string grantType)
        {
            var result = await _clientRepository.FindClientByIdAsync(clietId);

            if (result == null)
                throw new NotFoundException("Client can not be found");

            var grantTypes = result.AllowedGrantTypes;
            if (grantTypes.Length > 0)
            {
                var itExist = grantTypes.FirstOrDefault(x => x == grantType);
                if (itExist != null)
                    throw new AlreadyExistException($"{grantType}  already exist");
            }

            result.AllowedGrantTypes = grantTypes.Concat(new string[] { grantType }).ToArray();

            var res = await _clientRepository.UpdateClient(result);
            if (res == null)
                throw new BadRequestException("Update failed");

            return res;
        }

        public async Task<ClientModel> RemoveAllowedGrantType(string clietId, string grantType)
        {
            var result = await _clientRepository.FindClientByIdAsync(clietId);

            if (result == null)
                throw new NotFoundException("Client can not be found");

            var grantTypes = result.AllowedGrantTypes;
            if (grantTypes.Length <= 0)
            {
                throw new BadRequestException($"{grantType} does not exist");
            }
            var itExist = grantTypes.FirstOrDefault(x => x == grantType);
            if (itExist == null)
            {
                throw new BadRequestException($"{grantType} does not exist");
            }
            grantTypes = grantTypes.Where(x => x != grantType).ToArray();


            result.AllowedGrantTypes = grantTypes;

            var res = await _clientRepository.UpdateClient(result);
            if (res == null)
                throw new BadRequestException("Update failed");

            return res;
        }
    }
}
