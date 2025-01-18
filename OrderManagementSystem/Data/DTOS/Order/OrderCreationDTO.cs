namespace OrderManagementSystem.Data.DTOS.Order
{
    public class OrderCreationDTO
    {

        public int PersonId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
