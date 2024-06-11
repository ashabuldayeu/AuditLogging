using System.Collections.ObjectModel;

namespace AuditLogging.Core.Persistence
{
    public class AuditLogEntry : Collection<AuditProperty>
    {
        public AuditLogEntry(string eId, params AuditProperty[] properties) : base(properties)
        {
            EntityId = eId;
        }

        public Guid Id { get; set; }

        public string EntityId { get; set; }

        public IList<AuditProperty> Properties => Items;
    }
}
