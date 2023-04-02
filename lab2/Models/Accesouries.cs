using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public partial class Accesouries
    {
        public Accesouries()
        {
            Products = new HashSet<Product>();
        }


        public int Id;
        public string Name;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        //  public virtual Product Products { get; set; }
    }
}
