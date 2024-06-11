using AuditLogging.Core.Persistence;
using System.Collections.ObjectModel;

namespace AuditLogging.Core
{
    public class AuditLog(AuditLogEntry prev, AuditLogEntry curr) : Collection<AuditLogPropertyDifference>(MergeProperties(prev, curr))
    {
        private static List<AuditLogPropertyDifference> MergeProperties(AuditLogEntry prev, AuditLogEntry curr)
        {
            List<AuditLogPropertyDifference> changes = new(prev.Count);

            foreach (var prop in prev)
            {
                changes.Add(new(
                    prop.Name,
                    prop.Value,
                    curr.FirstOrDefault(x => x.Name == prop.Name)?.Value ?? null!));
            }
            // возможно тут сделать сортировОчку и дальше мы можем по индексам искать
            // либо словарик можно в аудит ентри сунуть тоже кайф в целом и общем:)
            return changes;
        }
    }
}
