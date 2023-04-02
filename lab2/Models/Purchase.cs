namespace lab2.Models
{
    public partial class Purchase
    {
        public Purchase()
        {
            
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int Id_client { get; set; }
        public int Id_adm { get; set; }
        public int TotalAmount { get; set; }
        public int Id_product { get; set; }


        //public virtual ICollection<Product> Products { get; set; }
        public virtual Administration Administrators { get; set; }
        public virtual Product Products { get; set; }
        public virtual Client Clients { get; set; }
    }
}
