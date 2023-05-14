using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities

{
    [Table("Accesouries")]
    public partial class Accesouries
    {
        public Accesouries()
        {
            Products = new HashSet<Product>();
        }


        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
        //  public virtual Product Products { get; set; }
    }
}
