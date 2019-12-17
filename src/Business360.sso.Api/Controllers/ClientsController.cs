using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business360.sso.Api.Models.Views;
using Business360.sso.Api.Models.VM;
using Business360.sso.Api.Utilities;
using Business360.sso.Core.Exceptions;
using Business360.sso.Core.Interfaces.Managers;
using Business360.sso.Core.Models;
using Business360.sso.Core.Utilities;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Business360.sso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientManager _clientManager;
        public ClientsController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientVM model)
        {
            model.Validate();
            var result = await _clientManager.Create(model.Map());
            return Ok(new ResponseModel<object>
            {
                RequestSuccessful = true,
                ResponseData = result,
                ResponseCode = Constants.ResponseCodes.Successful,
                Message = ""
            });
        }

        [HttpPost("{clientId}/addallowedcoruri")]
        public async Task<IActionResult> AddAllowCorOrigin(string clientId, [FromBody] BaseVM model)
        {
            model.Validate();

            if (string.IsNullOrEmpty(model.Value))
                throw new BadRequestException("Url is required");

            return Ok(new ResponseModel<ClientModel>
            {
                RequestSuccessful = true,
                ResponseCode = Constants.ResponseCodes.Successful,
                ResponseData = await _clientManager.AddAllowUri(clientId, model.Value),
                Message = $"{model.Value} has been added successfully"
            });
        }

        [HttpPost("{clientId}/removeallowedcoruri")]
        public async Task<IActionResult> RemoveAllowCorOrigin(string clientId, [FromBody] BaseVM model)
        {
            model.Validate();

            if (string.IsNullOrEmpty(model.Value))
                throw new BadRequestException("Url is required");

            return Ok(new ResponseModel<ClientModel>
            {
                RequestSuccessful = true,
                ResponseCode = Constants.ResponseCodes.Successful,
                ResponseData = await _clientManager.RemoveAllowUri(clientId, model.Value),
                Message = $"{model.Value} has been removed successfully"
            });
        }


        [HttpPost("{clientId}/addscopes")]
        public async Task<IActionResult> AddScopes(string clientId, [FromBody] BaseVM model)
        {

            model.Validate();

            if (string.IsNullOrEmpty(model.Value))
                throw new BadRequestException("Scope is required");

            return Ok(new ResponseModel<ClientModel>
            {
                RequestSuccessful = true,
                ResponseCode = Constants.ResponseCodes.Successful,
                ResponseData = await _clientManager.AddAllowedScope(clientId, model.Value),
                Message = $"{model.Value} has been added successfully"
            });
        }

        [HttpPost("{clientId}/removescopes")]
        public async Task<IActionResult> RemoveScopes(string clientId, [FromBody] BaseVM model)
        {
            model.Validate();

            if (string.IsNullOrEmpty(model.Value))
                throw new BadRequestException("Scope is required");

            return Ok(new ResponseModel<ClientModel>
            {
                RequestSuccessful = true,
                ResponseCode = Constants.ResponseCodes.Successful,
                ResponseData = await _clientManager.RemoveAllowedScope(clientId, model.Value),
                Message = $"{model.Value} has been removed successfully"
            });
        }


        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient(string clientId) => Ok(new ResponseModel<ClientModel>
        {
            RequestSuccessful = true,
            ResponseCode = Constants.ResponseCodes.Successful,
            ResponseData = await _clientManager.Get(clientId)
        });


        [HttpPost("{clientId}/addallowedgranttype")]
        public async Task<IActionResult> AddGrantType(string clientId, [FromBody] BaseVM model)
        {

            model.Validate();

            if (string.IsNullOrEmpty(model.Value))
                throw new BadRequestException("Grantype is required");

            return Ok(new ResponseModel<ClientModel>
            {
                RequestSuccessful = true,
                ResponseCode = Constants.ResponseCodes.Successful,
                ResponseData = await _clientManager.AddAllowedGrantType(clientId, model.Value),
                Message = $"{model.Value} has been added successfully"
            });
        }

        [HttpPost("{clientId}/removeallowedgranttype")]
        public async Task<IActionResult> RemoveGrantType(string clientId, [FromBody]BaseVM model)
        {
            model.Validate();

            if (string.IsNullOrEmpty(model.Value))
                throw new BadRequestException("Grant type is required");

            return Ok(new ResponseModel<ClientModel>
            {
                RequestSuccessful = true,
                ResponseCode = Constants.ResponseCodes.Successful,
                ResponseData = await _clientManager.RemoveAllowedGrantType(clientId, model.Value),
                Message = $"{model.Value} has been removed successfully"
            });
        }
    }
}