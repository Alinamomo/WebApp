namespace lab2.Models
{
    public partial class Client
    {
        public Client()
        {
            Purchases = new HashSet<Purchase>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Pasport { get; set; }
        public string DriverLicense { get; set; }


        public int Id_pur { get; set; }


        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
