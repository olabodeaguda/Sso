using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class SsoApi
    {
        public SsoApi()
        {
            UserClaims = new HashSet<SsoClaim>();
            SsoScopes = new HashSet<SsoScope>();
        }
        public long Id { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string ApiSecrets { get; set; }

        public ICollection<SsoClaim> UserClaims { get; set; }
        public ICollection<SsoScope> SsoScopes { get; set; }

    }
}
