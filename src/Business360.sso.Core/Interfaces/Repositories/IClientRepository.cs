using Business360.sso.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Core.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<ClientModel> FindClientByIdAsync(string clientId);
        Task<ClientModel> CreateClient(ClientModel client);
        Task<ClientModel> UpdateClient(ClientModel client);
    }
}
