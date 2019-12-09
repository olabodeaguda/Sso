using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class SsoClaim
    {
        public string Id { get; set; }
        public long OwnerId { get; set; }
        public string ClaimType { get; set; }

        [ForeignKey("OwnerId")]
        public SsoApi SsoApi { get; set; }

        [ForeignKey("OwnerId")]
        public SsoScope SsoScope { get; set; }
    }
}
