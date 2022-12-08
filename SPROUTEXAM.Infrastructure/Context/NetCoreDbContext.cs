using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SPROUTEXAM.Domain.Entities;

namespace SPROUTEXAM.Infrastructure.Context
{
    public class NetCoreDbContext : NetCoreBasedDbContext
    {
        public NetCoreDbContext(DbContextOptions<NetCoreDbContext> options) : base(options)
        {
        }

        public DbSet<Weather> Weathers { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditLogs = new List<AuditTrail>();
            var entries = ChangeTracker.Entries().Where(t => t.State == EntityState.Added).ToList();

            foreach (var entry in entries)
            {
                var tableName = entry.Entity.GetType().Name;

                if (entry.State == EntityState.Added)
                {
                    var props = new List<string>();
                    var currentValues = new List<string>();
                    var primaryKey = string.Empty;

                    foreach (var prop in entry.Properties.ToList())
                    {
                        var currentValue = prop.CurrentValue?.ToString();
                        if (string.IsNullOrEmpty(currentValue))
                            continue;

                        props.Add(prop.Metadata.Name);
                        currentValues.Add(currentValue);

                        if (prop.Metadata.IsPrimaryKey())
                            primaryKey = prop.Metadata.Name;
                    }

                    auditLogs.Add(new AuditTrail
                    {
                        Action = "Created",
                        Type = Domain.Enums.AuditTrailType.Created,
                        PrimaryKey = primaryKey,
                        ColumnName = string.Join(", ", props),
                        NewValue = string.Join(", ", currentValues),
                        OldValue = string.Empty,
                        Transaction = tableName,
                        User = ""
                    });

                }

                if (entry.State == EntityState.Modified)
                {

                }

                if (entry.State == EntityState.Deleted)
                {

                }
            }

            foreach (var audit in auditLogs)
            {
                AuditTrails.Add(audit);
            }
            
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}