namespace AuditLogging.Core.Persistence
{
    public class AuditProperty
    {
        public AuditProperty(string value, string name)
        {
            Value = value;
            Name = name;
        }

        public string Value { get; set; }

        public string Name { get; set; }
    }
}
