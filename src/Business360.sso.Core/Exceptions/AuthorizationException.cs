

using Business360.sso.Core.Utilities;

namespace Business360.sso.Core.Exceptions
{
    public class AuthorizationException : BaseException
    {

        public AuthorizationException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.Unauthorized;
            base.httpStatusCode = System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
