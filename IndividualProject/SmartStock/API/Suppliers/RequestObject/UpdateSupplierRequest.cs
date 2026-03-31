namespace SmartStock.API.Suppliers.RequestObject
{
    public class UpdateSupplierRequest : CreateSupplierRequest
    {
        public bool IsActive { get; set; }
    }
}
