using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("ModelRange")]
    public partial class ModelRange
    {
        public ModelRange()
        {
            // Constructions = new HashSet<Construction>();
            Models = new HashSet<AutoModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        // public virtual ICollection<Construction> Constructions { get; set; }
        //   public virtual Model model { get; set; }
        public virtual ICollection<AutoModel> Models { get; set; }
    }
}
