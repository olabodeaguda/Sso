using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Business360.sso.Core.Models
{
    public class ClientModel
    {

        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string AccessTokenType { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string[] RedirectUris { get; set; }
        public string[] PostLogoutRedirectUris { get; set; }
        public string[] AllowedScopes { get; set; }
        public string[] AllowedGrantTypes { get; set; }
        public string[] AllowedCorsOrigins { get; set; }
        public Claim[] Claims { get; set; }
        public string[] ClientSecrets { get; set; }
        public bool AllowOfflineAccess { get; set; } = true;
    }
}
