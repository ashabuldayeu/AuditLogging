using AuditLogging.Core.Config;
using AuditLogging.Core.Persistence;

namespace AuditLogging.Core.Factories
{
    public class AuditLogFactory : IAuditLogFactory
    {
        private readonly Dictionary<Type, IEntityAuditProvider> _configs;

        public AuditLogFactory(IEnumerable<IEntityAuditProvider> auditConfigs)
        {
            _configs = auditConfigs.ToDictionary(x => x.TargetEntity, x => x);
        }

        public bool TryLog(object entry, out AuditLogEntry log)
        {
            if(_configs.TryGetValue(entry.GetType(), out IEntityAuditProvider? config))
            {
                log = config.GetAudit(entry);

                return true;
            }

            log = null!;
            return false;
        }
    }
}
