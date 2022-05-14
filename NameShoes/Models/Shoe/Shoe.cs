namespace NameShoes.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
    }
}
