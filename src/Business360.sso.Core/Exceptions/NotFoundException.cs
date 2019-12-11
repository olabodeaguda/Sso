using Business360.sso.Core.Utilities;

namespace Business360.sso.Core.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.NotFound;
            base.httpStatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
