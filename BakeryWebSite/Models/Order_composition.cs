namespace BakeryWebSite.Models
{
    public class Order_composition
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId {  get; set; }
        public int GoodId { get; set; }
        public Order_composition() { }
        public Order_composition(int quantity, int orderId, int goodId)
        {
            Quantity = quantity;
            OrderId = orderId;
            GoodId = goodId;
        }
    }
}
