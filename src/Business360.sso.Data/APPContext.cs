using Business360.sso.Core.Interfaces.Services;
using Business360.sso.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business360.sso.Data
{
    public class APPContext : DbContext
    {
        private readonly IHttpAccessorService _httpContextAccessor;

        public APPContext(DbContextOptions<APPContext> options)
         : base(options)
        {
            _httpContextAccessor = (IHttpAccessorService)this.GetInfrastructure().GetService(typeof(IHttpAccessorService)); ;
        }

        public DbSet<SsoApi> SsoApis { get; set; }
        public DbSet<SsoClaim> SsoClaims { get; set; }
        public DbSet<SsoScope> SsoScopes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            FilterQuery(builder);
        }

        private void FilterQuery(ModelBuilder builder)
        {
            //builder.Entity<EmailLog>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
