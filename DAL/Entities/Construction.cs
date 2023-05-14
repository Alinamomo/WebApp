using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Construction")]
    public partial class Construction
    {
        public Construction()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string EngineType { get; set; }

        public int InStock { get; set; }
        public int Id_model { get; set; }
        public int Id_colour { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual AutoModel AutoModel { get; set; }
        public virtual Color Color { get; set; }

    }
}
