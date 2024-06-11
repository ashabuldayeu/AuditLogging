namespace AuditLogging.Core
{
    public record AuditLogPropertyDifference
    {
        public AuditLogPropertyDifference(string name, string prevValue, string newValue)
        {
            Name = name;
            PrevValue = prevValue;
            NewValue = newValue;
        }

        public string Name { get; set; }

        public string PrevValue { get; set; }

        public string NewValue { get; set; }
    }
}
