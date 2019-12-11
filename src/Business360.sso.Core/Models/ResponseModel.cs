using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Core.Models
{
    public class ResponseModel<T>
    {
        public bool RequestSuccessful { get; set; }
        public T ResponseData { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }
    }
}
