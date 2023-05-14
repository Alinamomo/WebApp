using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.Models
{
    public class PurchaseModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Id_status { get; set; }
        public int Id_client { get; set; }
        public int Id_adm { get; set; }
        public int Id_product { get; set; }
        public string StatusName { get; set; }
        public string ClientName { get; set; }
        public decimal Price { get; set; }
        public string AccessName { get; set; }
        public string ModelName { get; set; }

        public PurchaseModel() { }
        public PurchaseModel(DAL.Entities.Purchase purchase)
        {
            Id = purchase.Id;
            Date = (DateTime)purchase.Date;
            Id_client = (int)purchase.Id_client;
            Id_adm = (int)purchase.Id_adm;
            Id_product = (int)purchase.Id_product;
            
                     
        }
    }
}
