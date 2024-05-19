namespace BakeryWebSite.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Component(string name)
        {
            Name = name;
        }
        public Component() { }
    }
}
