namespace BakeryWebSite.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public double Total { get; set; }
        public int UserId { get; set; }
        public Order(string address, string status, double total, int userId)
        {
            Address = address;
            Status = status;
            Total = total;
            UserId = userId;
        }
        public Order() { } 
    }
}
