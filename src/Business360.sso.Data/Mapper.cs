using Business360.sso.Core.Models;
using IdentityServer4.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Business360.sso.Data
{
    public static class Mapper
    {
        public static string ToJsonString(this object obj)
        {
            if (obj == null)
                return string.Empty;
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.SerializeObject(obj, settings);
        }

        public static T ToObjectJsonString<T>(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return default(T);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;

            return JsonConvert.DeserializeObject<T>(obj, settings);
        }

        public static ClientModel Map(this Client entity)
        {
            if (entity == null)
                return null;

            string value = entity.ToJsonString();
            ClientModel model = value.ToObjectJsonString<ClientModel>();
            model.AllowedCorsOrigins = model.AllowedCorsOrigins ?? Array.Empty<string>();
            model.AllowedGrantTypes = model.AllowedGrantTypes ?? Array.Empty<string>();
            model.AllowedScopes = model.AllowedScopes ?? Array.Empty<string>();
            model.Claims = model.Claims ?? Array.Empty<Claim>();
            return model;
        }
        public static Client Map(this ClientModel model)
        {
            if (model == null)
                return null;

            string value = model.ToJsonString();
            Client entity = value.ToObjectJsonString<Client>();

            return entity;
        }

        public static ApiResource MiniMap(this ApiResource apiResource)
        {
            return new ApiResource
            {
                Name = apiResource.Name,
                DisplayName = apiResource.DisplayName,
                Description = apiResource.Description,
                UserClaims = new List<string> { "role" },
                ApiSecrets = new List<Secret> { new Secret("scopeSecret".Sha256()) },
                Scopes = apiResource.Scopes.Select(x =>
                    new Scope { Name = x.Name }
                ).ToArray()
            };
        }

        public static Client MiniMap(this Client client)
        {
            return new Client
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = client.ClientSecrets,
                AllowedScopes = client.AllowedScopes
            };
        }
    }
}
