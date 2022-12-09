using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Domain.Entities;

namespace SPROUTEXAM.Infrastructure.Context
{
  public class SproutExamDbContext : SproutExamBasedDbContext
    {
        public SproutExamDbContext(DbContextOptions<SproutExamDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}