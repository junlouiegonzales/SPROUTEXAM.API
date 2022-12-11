using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SPROUTEXAM.Infrastructure.Context
{
  public abstract class SproutExamBasedDbContext : IdentityDbContext
  {
    protected SproutExamBasedDbContext(DbContextOptions<SproutExamDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}