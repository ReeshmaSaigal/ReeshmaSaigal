namespace SmartStock.API.Category.RequestObject
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
