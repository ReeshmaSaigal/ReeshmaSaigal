namespace SmartStock.API.Stocks.RequestObjects
{
    public class CreateStockRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
