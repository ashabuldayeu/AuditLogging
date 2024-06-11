using AuditLogging.Core.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AuditLogging.Contexts.Interceptors
{
    public class AuditSaveChangesInterceptor(IServiceProvider services) : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var ctx = eventData.Context;
            // for 1st audit row 
            var addedEntries = ctx
                .ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added);

            foreach ( var entry in addedEntries )
            {
                entry.
                // тут надо будет своротить некую фабрику с кастами в конкретный генерик тайп
                services.GetServices<AuditConfig>
            }

            var modifiedEntries = ctx
                .ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified);



            return base.SavingChanges(eventData, result);
        }
    }
}
