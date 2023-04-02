namespace lab2.Models
{
    public partial class Construction
    {
        public Construction()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string EngineType { get; set; }

        public int InStock { get; set; }
        public int Id_model { get; set; }
        public int Id_colour { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual AutoModel AutoModel { get; set; }
        public virtual Color Color { get; set; }

    }
}
