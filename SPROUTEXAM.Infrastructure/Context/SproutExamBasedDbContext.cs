using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SPROUTEXAM.Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

namespace SPROUTEXAM.Infrastructure.Context
{
    public abstract class SproutExamBasedDbContext : ApiAuthorizationDbContext<UserAccount>
    {
        protected SproutExamBasedDbContext(DbContextOptions<SproutExamDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions)
                : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}