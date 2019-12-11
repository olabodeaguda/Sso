using Business360.sso.Core.Utilities;


namespace Business360.sso.Core.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.Failed;
            base.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
