using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SPROUTEXAM.Domain.Entities;

namespace SPROUTEXAM.Infrastructure.Context
{
  public class SproutExamDbContext : SproutExamBasedDbContext
    {
        public SproutExamDbContext(DbContextOptions<SproutExamDbContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}