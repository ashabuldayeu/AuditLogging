using AuditLogging.Core.Persistence;

namespace AuditLogging.Core
{
    public class AuditCollection
    {
        private readonly List<AuditLogEntry> _entries = [];
        private const int window_size = 1;
        public IEnumerable<AuditLog> GetLogs()
        {
            for (int i = 0; i < _entries.Count - 1; i++)
            {
                yield return new AuditLog(_entries[i], _entries[i + window_size]);
            }
        }
    }
}
