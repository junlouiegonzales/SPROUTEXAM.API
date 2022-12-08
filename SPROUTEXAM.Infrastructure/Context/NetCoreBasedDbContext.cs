using Microsoft.EntityFrameworkCore;

namespace SPROUTEXAM.Infrastructure.Context
{
    public abstract class NetCoreBasedDbContext : DbContext
    {
        protected NetCoreBasedDbContext(DbContextOptions<NetCoreDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var auditLogs = new List<AuditTrail>();
        //    var entries = ChangeTracker.Entries().Where(t => t.State == EntityState.Added).ToList();

        //    foreach (var entry in entries)
        //    {
        //        var tableName = entry.Entity.GetType().Name;
          
        //        if (entry.State == EntityState.Added)
        //        {
        //            var props = new List<string>();
        //            var currentValues = new List<string>();
        //            var primaryKey = string.Empty;

        //            foreach (var prop in entry.Properties.ToList())
        //            {
        //                var currentValue = prop.CurrentValue?.ToString();
        //                if(string.IsNullOrEmpty(currentValue))
        //                    continue;

        //                props.Add(prop.Metadata.Name);
        //                currentValues.Add(currentValue);

        //                primaryKey = prop.Metadata.IsPrimaryKey()
        //                    ? currentValue
        //                    : null;
        //            }

        //            auditLogs.Add(new AuditTrail
        //            {
        //                Action = "Created",
        //                Type = Domain.Enums.AuditTrailType.Created,
        //                PrimaryKey = primaryKey,
        //                ColumnName = string.Join(", ", props),
        //                NewValue = string.Join(", ", currentValues),
        //                OldValue = string.Empty,
        //                Transaction = tableName,
        //                User = ""
        //            });

        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
                    
        //        }

        //        if (entry.State == EntityState.Deleted)
        //        {
                    
        //        }   
        //    }

            

        //    return (await base.SaveChangesAsync(true, cancellationToken));
        //}
    }
}