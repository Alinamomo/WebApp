using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Administration")]
    public partial class Administration
    {
        public Administration()
        {
            Purchases = new HashSet<Purchase>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public int Experience { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
