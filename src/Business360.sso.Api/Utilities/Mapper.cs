using Business360.sso.Api.Models.Views;
using Business360.sso.Core.Models;

namespace Business360.sso.Api.Utilities
{
    public static class Mapper
    {
        public static ClientModel Map(this ClientVM model)
        {
            if (model == null)
                return null;

            ClientModel client = new ClientModel();
            client.ClientName = model.ClientName;
            client.ClientId = model.ClientId;
            client.AccessTokenType = model.AccessTokenType.ToString();
            client.AccessTokenLifetime = model.AccessTokenLifetime;
            client.IdentityTokenLifetime = model.IdentityTokenLifetime;
            client.AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken;
            client.AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser;
            client.RedirectUris = new string[] { model.RedirectUris };
            client.PostLogoutRedirectUris = new string[] { model.PostLogoutRedirectUris };

            return client;
        }
    }
}
