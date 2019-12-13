using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business360.sso.Api.Models.VM
{
    public class BaseVM : Model
    {
        //[DataType(DataType.Url, ErrorMessage = "Invalid url")]
        //[Required(ErrorMessage = "Uri is required")]
        public string Value { get; set; }
    }
}
