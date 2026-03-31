namespace SmartStock.API.Suppliers.RequestObject
{
    public class CreateSupplierRequest
    {
        public string SupplierName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
