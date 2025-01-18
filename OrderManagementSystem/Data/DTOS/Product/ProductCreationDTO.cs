namespace OrderManagementSystem.Data.DTOS.Product
{
    public class ProductCreationDTO
    {
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}
