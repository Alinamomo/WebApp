using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL.Entities;

namespace BLL.Models
{
    public class AutoModelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public int ModelRangeId { get; set; }
        public decimal MinPrice { get; set; }
        public AutoModelModel(DAL.Entities.AutoModel model)
        {
            MinPrice = decimal.MaxValue;
            var Constructions = model.Constructions.ToList();
            foreach(var pr in Constructions)
            {
                decimal p = (decimal) pr.Products.OrderBy(i => i.Price).FirstOrDefault().Price;
                if (p < MinPrice)
                    MinPrice = p;
            }
            Id = model.Id;
            Name = model.Name;
            ModelRangeId = (int)model.Id_modelrange;
           //ImageSource = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Sources\\Model_" + Name + ".png";
        }
    }
}
