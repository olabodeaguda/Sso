using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Core.Interfaces.Managers
{
    public interface IClientManager
    {
        Task<object> Create(object clt);
    }
}
