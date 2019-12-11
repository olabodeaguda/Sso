using Business360.sso.Core.Interfaces.Managers;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Infrastructure.Managers
{
    public class ClientManager : IClientManager
    {
        public async Task<object> Create(object clt)
        {
            var client = (Client)clt;

            throw new NotImplementedException();
        }
    }
}
