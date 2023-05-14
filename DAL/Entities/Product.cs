using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Product")]
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
        public int? Id_acc { get; set; }
        public int? Id_constr { get; set; }



        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual Construction Constructions { get; set; }
        public virtual Accesouries Accesouries { get; set; }

    }
}
