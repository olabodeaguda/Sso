using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business360.sso.Data.Entities
{
    public class ApiResource
    {
        public string ApiResourceData { get; set; }

        [Key]
        public string ApiResourceName { get; set; }
    }
}
