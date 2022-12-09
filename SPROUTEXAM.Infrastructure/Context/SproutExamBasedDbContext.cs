using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Domain.Entities;

namespace SPROUTEXAM.Infrastructure.Context
{
    public abstract class SproutExamBasedDbContext : IdentityDbContext<UserAccount>
    {
        protected SproutExamBasedDbContext(DbContextOptions<SproutExamDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}