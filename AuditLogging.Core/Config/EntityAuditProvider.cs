using AuditLogging.Core.Persistence;

namespace AuditLogging.Core.Config
{
    public class EntityAuditProvider<TEntity> : IEntityAuditProvider
    {
        private readonly Func<TEntity, AuditLogEntry> _map;

        public EntityAuditProvider(Func<TEntity, AuditLogEntry> map)
        {
            ArgumentNullException.ThrowIfNull(_map);
            _map = map;
        }

        public Type TargetEntity => typeof(TEntity);

        public AuditLogEntry GetAudit(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            return _map(entity);
        }

        AuditLogEntry IEntityAuditProvider.GetAudit(object entity) => GetAudit((TEntity)entity);
    }
}
