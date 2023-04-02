namespace lab2.Models
{
    public partial class Color
    {
        public Color()
        {
            Constructions = new HashSet<Construction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Construction> Constructions { get; set; }
    }
}
