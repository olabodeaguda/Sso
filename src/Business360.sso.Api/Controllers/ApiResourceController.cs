using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business360.sso.Api.Models.VM;
using Business360.sso.Core.Exceptions;
using Business360.sso.Core.Interfaces.Managers;
using Business360.sso.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Business360.sso.Core.Utilities.Constants;

namespace Business360.sso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiResourceController : ControllerBase
    {
        ////create apiresource
        //// add, remove scope
        //// add, remove claims
        //private readonly IApiResourceManager _apiResourceManager;
        //public ApiResourceController(IApiResourceManager apiResourceManager)
        //{
        //    _apiResourceManager = apiResourceManager;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] ApiResourceVM model)
        //{
        //    model.Validate();
        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        Message = "Api resource has been created successfully",
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        ResponseData = await _apiResourceManager.CreateApiResource(new ApiResourceModel
        //        {
        //            DisplayName = model.DisplayName,
        //            Name = model.Name
        //        })
        //    });
        //}

        //[HttpPost("{resourcename}/activate")]
        //public async Task<IActionResult> Activate(string resourcename)
        //{
        //    if (string.IsNullOrEmpty(resourcename))
        //        throw new BadRequestException("Resource name is required");

        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        Message = "Api resource has been activated successfully",
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        ResponseData = await _apiResourceManager.ActivateApiResource(resourcename)
        //    });
        //}

        //[HttpPost("{resourcename}/deactivate")]
        //public async Task<IActionResult> Deactivate(string resourcename)
        //{
        //    if (string.IsNullOrEmpty(resourcename))
        //        throw new BadRequestException("Resource name is required");

        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        Message = "Api resource has been deactivated successfully",
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        ResponseData = await _apiResourceManager.DeactivateApiResource(resourcename)
        //    });
        //}

        //[HttpPost("{resourceName}/addscope")]
        //public async Task<IActionResult> AddScope([FromBody] ScopeVm model, string resourceName)
        //{
        //    model.Validate();

        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        Message = $"{model.DisplayName} has been added successfully",
        //        ResponseData = await _apiResourceManager.CreateScope(resourceName, model.Name, model.DisplayName)
        //    });
        //}

        //[HttpPost("{resourceName}/addclaim")]
        //public async Task<IActionResult> AddClaim([FromBody] BaseVM model, string resourceName)
        //{
        //    if (string.IsNullOrEmpty(model.Value))
        //        throw new BadRequestException("Claim type is required");

        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        Message = $"{model.Value} has been added successfully",
        //        ResponseData = await _apiResourceManager.CreateClaims(resourceName, model.Value)
        //    });
        //}

        //[HttpPost("{resourcename}/removescope/{scopename}")]
        //public async Task<IActionResult> RemoveScope(string resourcename, string scopename)
        //{
        //    if (string.IsNullOrEmpty(resourcename))
        //        throw new BadRequestException("Resource name is required");
        //    if (string.IsNullOrEmpty(scopename))
        //        throw new BadRequestException("Scope name is required");
        //    var result = await _apiResourceManager.RemoveScope(resourcename, scopename);

        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        Message = "Api scope has been removed successfully",
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        ResponseData = result
        //    });
        //}

        //[HttpPost("{resourcename}/removeclaim/{scopename}")]
        //public async Task<IActionResult> RemoveClaim(string resourcename, string claimtype)
        //{
        //    if (string.IsNullOrEmpty(resourcename))
        //        throw new BadRequestException("Resource name is required");
        //    if (string.IsNullOrEmpty(claimtype))
        //        throw new BadRequestException("Scope name is required");
        //    var result = await _apiResourceManager.RemoveClaims(resourcename, claimtype);

        //    return Ok(new ResponseModel<ApiResourceModel>
        //    {
        //        Message = "Api claim has been removed successfully",
        //        RequestSuccessful = true,
        //        ResponseCode = ResponseCodes.Successful,
        //        ResponseData = result
        //    });
        //}

        //[HttpGet("{resourcename}")]
        //public async Task<IActionResult> Get(string resourcename) => Ok(new ResponseModel<object>
        //{
        //    RequestSuccessful = true,
        //    ResponseCode = ResponseCodes.Successful,
        //    ResponseData = await _apiResourceManager.Get(resourcename)
        //});
    }
}