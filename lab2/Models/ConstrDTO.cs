using Microsoft.Identity.Client;
using System.Text.Json.Serialization;
using lab2.Models;
namespace lab2.Models

{
    public class ConstrDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int id_model { get; set; }
        public int id_colour { get; set; }
        public int HorsePower { get; set; }
        public string Transmission { get; set; }
        public double EngineCapacity { get; set; }
        public string Drive { get; set; }
        public string EngineType { get; set;}
        public int InStock { get; set; }

        [JsonConstructor]
        public ConstrDTO() { }

    }
}
