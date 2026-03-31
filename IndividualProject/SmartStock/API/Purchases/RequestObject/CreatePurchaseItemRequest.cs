namespace SmartStock.API.Purchases.RequestObject
{
    public class CreatePurchaseItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
    }
}
