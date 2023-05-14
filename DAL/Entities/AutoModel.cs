using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("AutoModel")]
    public partial class AutoModel
    {

        public AutoModel()
        {
            Constructions = new HashSet<Construction>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Id_modelrange { get; set; }

        public virtual ModelRange Range { get; set; }
        public virtual ICollection<Construction> Constructions { get; set; }
    }
}
