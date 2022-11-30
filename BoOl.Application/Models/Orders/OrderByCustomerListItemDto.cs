namespace BoOl.Application.Models.Orders
{
    public class OrderByCustomerListItemDto
    {
        public int Id { get; set; }
        public string ProductSerialNumber { get; set; }
        public string Status { get; set; }
        public string Payment { get; set; }
    }
}
