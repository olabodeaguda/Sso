using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class SsoScope
    {
        public SsoScope()
        {
            SSoClaims = new HashSet<SsoClaim>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public string ShowInDiscoveryDocument { get; set; }

        public ICollection<SsoClaim> SSoClaims { get; set; }
    }
}
