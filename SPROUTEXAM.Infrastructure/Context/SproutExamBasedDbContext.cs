using Microsoft.EntityFrameworkCore;

namespace SPROUTEXAM.Infrastructure.Context
{
    public abstract class SproutExamBasedDbContext : DbContext
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