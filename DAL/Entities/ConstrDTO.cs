using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ConstrDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int id_model { get; set; }
        public int id_color { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string EngineType { get; set; }
        public int InStock { get; set; }

        [JsonConstructor]
        public ConstrDTO() { }

    }
}
