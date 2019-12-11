using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Core.Utilities
{
    public static class Constants
    {
        public static class ResponseCodes
        {
            public const string Successful = "00";
            public const string Failed = "99";
            public const string AlreadyExist = "02";
            public const string NotFound = "03";
            public const string InvalidIssuer = "04";
            public const string TokenExpired = "05";
            public const string TokenValidationFailed = "06";
            public const string InvalidAudience = "07";
            public const string Unauthorized = "08";
            public const string ModelValidation = "09";
            public const string UserNotConfirmed = "10";
        }
    }
}
