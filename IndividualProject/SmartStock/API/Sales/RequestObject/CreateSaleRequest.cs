namespace SmartStock.API.Sales.RequestObject
{
    public class CreateSaleRequest
    {
        public string CustomerName { get; set; } = null!;
        public List<CreateSaleItemRequest> Items { get; set; } = new();
    }
}
