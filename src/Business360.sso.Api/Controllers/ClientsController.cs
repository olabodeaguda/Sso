using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business360.sso.Api.Models.Views;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Business360.sso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        public async Task<IActionResult> Create([FromBody] ClientVM model)
        {
            model.Validate();

            await Task.Yield();
            return Ok();
        }

        [HttpPost("{clientId}/addcoruri")]
        public async Task<IActionResult> AddAllowCorOrigin(string clientId)
        {
            await Task.Yield();
            return Ok();
        }

        [HttpPost("{clientId}/removecoruri")]
        public async Task<IActionResult> RemoveAllowCorOrigin(string clientId)
        {
            await Task.Yield();
            return Ok();
        }

        [HttpPost("{clientId}/addscopes")]
        public async Task<IActionResult> AddScopes(string clientId)
        {
            await Task.Yield();
            return Ok();
        }

        [HttpPost("{clientId}/removescopes")]
        public async Task<IActionResult> RemoveScopes(string clientId)
        {
            await Task.Yield();
            return Ok();
        }


        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClient(string clientId)
        {
            await Task.Yield();
            return Ok();
        }


        [HttpGet("{clientId}/addgranttype")]
        public async Task<IActionResult> AddGrantType(string clientId)
        {
            await Task.Yield();
            return Ok();
        }

        [HttpGet("{clientId}/removegranttype")]
        public async Task<IActionResult> RemoveGrantType(string clientId)
        {
            await Task.Yield();
            return Ok();
        }
    }
}