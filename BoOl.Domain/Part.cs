namespace BoOl.Domain
{
    public class Part
    {
        public int Id { get; set; }
        public bool IsInjured { get; set; }

        public string SerialNumber { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }

        public int CustomServiceId { get; set; }
        public CustomService CustomService { get; set; }
    }
}
