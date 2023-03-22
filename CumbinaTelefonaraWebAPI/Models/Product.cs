namespace CumbinaTelefonaraWebAPI.Models
{
    public abstract class Product
    {
        public int Id { get; set; }
        public abstract string Type { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}
