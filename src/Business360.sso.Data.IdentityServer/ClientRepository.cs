using Business360.sso.Core.Interfaces;
using Business360.sso.Core.Interfaces.Repositories;
using Business360.sso.Core.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Data.IdentityServer
{
    public class ClientRepository : IClientRepository
    {
        private readonly DbContext _context;
        private readonly IClientStore _clientStore;
        public ClientRepository(IClientStore clientStore, DbContext dbContext)
        {
            _context = dbContext;
            _clientStore = clientStore;
        }

        public async Task<ClientModel> CreateClient(ClientModel model)
        {
            return null;
        }

        public async Task<ClientModel> FindClientByIdAsync(string clientId)
        {
            return null;
        }

        public async Task<ClientModel> UpdateClient(ClientModel model)
        {
            return null;
        }
    }
}
