using IdentityServer4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Core.Models.ConfigurationStore
{
    public class ApiResourceEntity
    {
        public string ApiResourceData { get; set; }

        public string ApiResourceName { get; set; }

        public ApiResource ApiResource { get; set; }

        public void AddDataToEntity()
        {
            ApiResourceData = JsonConvert.SerializeObject(ApiResource);
            ApiResourceName = ApiResource.Name;
        }

        public void MapDataFromEntity()
        {
            ApiResource = JsonConvert.DeserializeObject<ApiResource>(ApiResourceData);
            ApiResourceName = ApiResource.Name;
        }
    }
}
