using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business360.sso.Data.Repositories
{
    public class ClientStore : IClientStore
    {
        private readonly APPDbContext _context;

        public ClientStore(APPDbContext context)
        {
            _context = context;
        }

        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(t => t.ClientId == clientId);
            //client.MapDataFromEntity();
            return client.ClientData.ToObjectJsonString<Client>();
        }
    }
}
