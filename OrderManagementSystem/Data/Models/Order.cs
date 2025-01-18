namespace OrderManagementSystem.Data.Models
{
    public class Order
    {
        // public Guid Id { get; set; } guid is interesting
        public int Id { get; set; }
        public User Person { get; set; }
        public List<Product> Products { get; set; }
    }
}
