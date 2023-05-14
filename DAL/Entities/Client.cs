using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Client")]
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
