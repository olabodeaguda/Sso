using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business360.sso.Api.Models.VM
{
    public class ScopeVm : Model
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Display name is required")]
        public string DisplayName { get; set; }
    }
}
