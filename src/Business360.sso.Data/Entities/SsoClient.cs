using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class SsoClient
    {
        public string ClientData { get; set; }

        [Key]
        public string ClientId { get; set; }
    }
}
