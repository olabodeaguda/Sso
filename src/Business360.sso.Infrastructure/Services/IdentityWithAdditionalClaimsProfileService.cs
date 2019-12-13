using Business360.sso.Data.Entities;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business360.sso.Infrastructure.Services
{
    public class IdentityWithAdditionalClaimsProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityWithAdditionalClaimsProfileService(UserManager<ApplicationUser> userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
        {
            _userManager = userManager;
            _claimsFactory = claimsFactory;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();

            var user = await _userManager.FindByIdAsync(sub);
            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();

            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();


            //claims.Add(new Claim(JwtClaimTypes.GivenName, user.UserName),
            claims.Add(new Claim(JwtClaimTypes.Role, "admin"));

            //new Claim(JwtClaimTypes.Role, "dataEventRecords.admin"),
            //new Claim(JwtClaimTypes.Role, "dataEventRecords.user"),
            //new Claim(JwtClaimTypes.Role, "dataEventRecords"),
            //new Claim(JwtClaimTypes.Role, "securedFiles.user"),
            //new Claim(JwtClaimTypes.Role, "securedFiles.admin"),
            //new Claim(JwtClaimTypes.Role, "securedFiles"));


            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);
            context.IsActive = user != null;
        }
    }
}
