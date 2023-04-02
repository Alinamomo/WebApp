namespace lab2.Models
{
    public partial class Administration
    {
        public Administration()
        {
            Purchases = new HashSet<Purchase>();
        }
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public int Experience { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
