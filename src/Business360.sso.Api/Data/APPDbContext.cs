﻿using Business360.sso.Core.Interfaces.Services;
using Business360.sso.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Api.Data
{
    public class APPDbContext : IdentityDbContext<ApplicationUser> //DbContext
    {
        private readonly IHttpAccessorService _httpContextAccessor;

        public APPDbContext(DbContextOptions<APPDbContext> options)
         : base(options)
        {
            _httpContextAccessor = (IHttpAccessorService)this.GetInfrastructure().GetService(typeof(IHttpAccessorService)); ;
        }

        //public DbSet<SsoApiResource> ApiResources { get; set; }
        //public DbSet<SsoClient> Clients { get; set; }
        //public DbSet<IdentityResource> IdentityResources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<SsoClient>().HasKey(m => m.ClientId);
            //builder.Entity<SsoApiResource>().HasKey(m => m.ApiResourceName);
            //builder.Entity<IdentityResource>().HasKey(m => m.IdentityResourceName);

            FilterQuery(builder);
        }

        private void FilterQuery(ModelBuilder builder)
        {
            //builder.Entity<EmailLog>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
