using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business360.sso.Api.Models.Views
{
    public class ClientVM : Model
    {
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public AccessTokenType AccessTokenType { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string RedirectUris { get; set; }
        public string PostLogoutRedirectUris { get; set; }

    }
}
