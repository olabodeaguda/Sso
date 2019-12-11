


using Business360.sso.Core.Utilities;

namespace Business360.sso.Core.Exceptions
{
    public class AlreadyExistException : BaseException
    {
        public AlreadyExistException(string message) : base(message)
        {
            base.Code = Constants.ResponseCodes.AlreadyExist;
            base.httpStatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
