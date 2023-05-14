using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BLL.Models
{
    public class AccesouriesModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public decimal MinimalPrice { get; set; }
        public string ImageSource { get; set; }
        public AccesouriesModel(Accesouries accesouries)
        {
            Id = accesouries.Id;
            Name = accesouries.Name;
            MinimalPrice =  (decimal)accesouries.Products.OrderBy(i => i.Price).FirstOrDefault().Price;

           // ImageSource = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Sources\\Acces_" + Id + ".png";
        }


    }
}
