namespace lab2.Models
{
    public partial class Product
    {
        public Product()
        {
            // Constructions = new HashSet<Construction>();
            //  Accesouriess = new HashSet<Accesouries>();
            Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Id_acc { get; set; }
        public int Id_constr { get; set; }



         public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Construction Constructions { get; set; }
        public virtual Accesouries Accesouries { get; set; }

      

    }
}
