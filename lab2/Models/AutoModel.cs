namespace lab2.Models
{
    public partial class AutoModel
    {

        public AutoModel()
        {
            Constructions = new HashSet<Construction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_modelrange { get; set; }

        public virtual ModelRange Range { get; set; }
        public virtual ICollection<Construction> Constructions { get; set; }
    }
}
