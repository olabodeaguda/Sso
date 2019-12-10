using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Data
{
    public static class Mapper
    {
        public static string ToJsonString(this object obj)
        {
            if (obj == null)
                return string.Empty;

            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObjectJsonString<T>(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return default(T);

            return JsonConvert.DeserializeObject<T>(obj);
        }
    }
}
