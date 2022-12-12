namespace BoOl.Application.Models.Parts
{
    public class PartDto
    {
        public int? Id { get; set; }
        public bool IsInjured { get; set; }
        public string SerialNumber { get; set; }
        public int StorageId { get; set; }
        public int CustomServiceId { get; set; }
        public string StorageName { get; set; }
    }
}
