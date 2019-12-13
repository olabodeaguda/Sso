using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Core.Models
{
    public class ApiResourceModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public ScopeModel[] Scopes { get; set; }
        public string[] UserClaims { get; set; }
    }
}
