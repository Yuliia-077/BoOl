namespace BoOl.Application.Models.Products
{
    public class ProductDto
    {
        public int? Id { get; set; }
        public string SerialNumber { get; set; }
        public string AdditionalInf { get; set; }
        public int ModelId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
