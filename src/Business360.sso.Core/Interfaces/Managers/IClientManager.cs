using Business360.sso.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Core.Interfaces.Managers
{
    public interface IClientManager
    {
        Task<ClientModel> Create(ClientModel clt);
        Task<ClientModel> Get(string clientId);
        Task<ClientModel> AddAllowUri(string clietId, string url);
        Task<ClientModel> RemoveAllowUri(string clietId, string url);

        Task<ClientModel> AddAllowedScope(string clietId, string scope);
        Task<ClientModel> RemoveAllowedScope(string clietId, string scope);

        Task<ClientModel> AddAllowedGrantType(string clietId, string grantType);
        Task<ClientModel> RemoveAllowedGrantType(string clietId, string grantType);
    }
}
