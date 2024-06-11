using AuditLogging.Core.Persistence;

namespace AuditLogging.Core.Config
{
    public interface IEntityAuditProvider
    {
        Type TargetEntity { get; }

        AuditLogEntry GetAudit(object entity);
    }
}
