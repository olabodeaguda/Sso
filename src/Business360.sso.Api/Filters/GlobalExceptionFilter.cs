using Business360.sso.Core.Exceptions;
using Business360.sso.Core.Models;
using Business360.sso.Core.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Business360.sso.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var content = GetStatusCode<object>(context.Exception);
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)content.Item2;
            response.ContentType = "application/json";

            context.Result = new JsonResult(content.Item1);
        }

        public static (ResponseModel<T> responseModel, HttpStatusCode statusCode) GetStatusCode<T>(Exception exception)
        {
            switch (exception)
            {
                case BaseException bex:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = bex.Code,
                        Message = bex.Message,
                        RequestSuccessful = false,
                    }, bex.httpStatusCode);
                case SecurityTokenExpiredException bex:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = Constants.ResponseCodes.TokenExpired,
                        Message = "Session expired",
                        RequestSuccessful = false,
                    }, HttpStatusCode.Unauthorized);
                case ValidationException bex:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = Constants.ResponseCodes.ModelValidation,
                        Message = bex.Message,
                        RequestSuccessful = false,
                    }, HttpStatusCode.BadRequest);
                case SecurityTokenValidationException bex:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = Constants.ResponseCodes.TokenValidationFailed,
                        Message = "Invalid authentication parameters",
                        RequestSuccessful = false,
                    }, HttpStatusCode.Unauthorized);
                default:
                    return (new ResponseModel<T>
                    {
                        ResponseCode = Constants.ResponseCodes.Failed,
                        Message = exception.Message,
                        RequestSuccessful = false
                    }, HttpStatusCode.InternalServerError);
            }
        }
    }
}
