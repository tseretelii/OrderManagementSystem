namespace OrderManagementSystem.Data.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
