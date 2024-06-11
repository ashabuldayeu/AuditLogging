namespace AuditLogging.Entities
{
    public class TestRootObj
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<InnerObj> InnerObjs { get; set; }

        public ComplexObj ComplexObj { get; set; }
    }
}
