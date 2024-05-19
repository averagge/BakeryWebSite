namespace BakeryWebSite.Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price{ get; set; }
        public string Image { get; set; }
        public int Categories_Id { get; set; }
        public int Weight {  get; set; }
        public Good(string name, double price, string image, int categoryId, int weight) 
        {
            Name = name;
            Price = price;
            Image = image;
            Categories_Id = categoryId;
            Weight = weight;
        }
        public Good() { }
    }
}
