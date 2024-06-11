using AuditLogging.Core.Persistence;

namespace AuditLogging.Core.Config
{
    public class AuditConfig<TEntity> 
    {
        private readonly Func<TEntity, AuditLogEntry> _map;

        public AuditConfig(Func<TEntity, AuditLogEntry> map)
        {
            ArgumentNullException.ThrowIfNull(_map);
            _map = map;
        }

        public AuditLogEntry Map(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            return _map(entity);
        }
    }
}
