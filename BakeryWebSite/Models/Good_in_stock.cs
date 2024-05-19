namespace BakeryWebSite.Models
{
    public class Good_in_stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int GoodId {  get; set; }
        public Good_in_stock() { }
        public Good_in_stock(int quantity, int goodId)
        {
            Quantity = quantity;
            GoodId = goodId;
        }
    }
}
