using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BLL.Models
{
    public class ConstructionModel
    {
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
        public string? Color_name { get; set; }
        public decimal Price { get; set; }

        [JsonConstructor]
        public ConstructionModel() { }

        public ConstructionModel(DAL.Entities.Construction constr, IDbRepos db)
        {
            
            Id = constr.Id;
            Name = constr.Name;
            HorsePower = (int)constr.HorsePower;
            Transmission = constr.Transmission;
            EngineCapacity = (double)constr.EngineCapacity;
            Drive = constr.Drive;
            EngineType = constr.EngineType;
            Id_model = (int)constr.Id_model;
            Id_colour = (int)constr.Id_colour;
            InStock = (int)constr.InStock;
            Color_name = db.Colors.GetItem(Id_colour).Name;
            var purch = db.Products.GetList().Where(i => i.Id_constr == Id).ToList();
            if (purch.Count > 0)
                Price = purch.Min(i => i.Price);
            else
                Price = -1;

        }
    }
}
