namespace SmartStock.API.Purchases.RequestObject
{
    public class CreatePurchaseRequest
    {
        public Guid SupplierId { get; set; }
        public List<CreatePurchaseItemRequest> Items { get; set; } = new();
    }
}
