using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Purchase")]
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
