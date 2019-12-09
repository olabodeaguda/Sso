using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class SsoClient
    {
        public long Id { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public string AllowedGrantTypes { get; set; }
        public string RedirectUris { get; set; }
        public string PostLogoutRedirectUris { get; set; }
        public string AllowedCorsOrigins { get; set; }

        public ICollection<SsoScope> SsoScopes { get; set; }
    }
}
