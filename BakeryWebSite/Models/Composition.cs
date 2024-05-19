namespace BakeryWebSite.Models
{
    public class Composition
    {
        public int Id { get; set; }
        public int Components_Id {  get; set; }
        public int Goods_Id {  get; set; }
        public Composition() { }
        public Composition(int componentId, int goodId)
        {
            Components_Id = componentId;
            Goods_Id = goodId;
        }
    }
}
