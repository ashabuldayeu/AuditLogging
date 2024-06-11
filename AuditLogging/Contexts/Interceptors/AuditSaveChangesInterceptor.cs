using AuditLogging.Core.Config;
using AuditLogging.Core.Factories;
using AuditLogging.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AuditLogging.Contexts.Interceptors
{
    public class AuditSaveChangesInterceptor(IAuditLogFactory auditLogFactory) : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var ctx = eventData.Context!;
            // for 1st audit row 
            var addedEntries = ctx
                .ChangeTracker
                .Entries()
                .Where(x => x.State is EntityState.Added or EntityState.Modified);

            List<AuditLogEntry> entries = [];
            foreach (var entry in addedEntries)
            {
                // тут надо будет своротить некую фабрику с кастами в конкретный генерик тайп
                auditLogFactory.TryLog(entry, out var log);

                if (log != null)
                {
                    entries.Add(log);
                }
            }

            await ctx.Set<AuditLogEntry>().AddRangeAsync(entries);

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
