namespace SmartStock.API.Products.RequestObject
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = null!;
        public Guid CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
