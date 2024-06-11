using AuditLogging.Core.Persistence;

namespace AuditLogging.Core.Factories
{
    public interface IAuditLogFactory
    {
        bool TryLog(object entry, out AuditLogEntry log);
    }
}
