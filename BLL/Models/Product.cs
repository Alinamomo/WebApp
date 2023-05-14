using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set;  }
        public decimal Price { get; set; }
        public int? id_acc { get; set; }
        public int ?id_constr { get; set; }
        public string ProductName { get; set; }

        public ProductModel(DAL.Entities.Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price =(decimal)product.Price;
            id_acc = product.Id_acc;
            id_constr = product.Id_constr;

            string AccessName = product.Accesouries == null ? "" : " " + product.Accesouries.Name;
            string ModelName = product.Constructions == null ? "" : product.Constructions.Name + " " + product.Constructions.AutoModel.Name;
            ProductName = ModelName + AccessName;
        }

    }
}
