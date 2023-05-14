using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ClientPurchaseModel
    {
            public int Id { get; set; }

            public string FullName { get; set; }
            public string Pasport { get; set; }
            public string DriverLicense { get; set; }

            public DateTime Date { get; set; }
            public int Id_product { get; set; }

            public int Id_adm { get; set; }
            public decimal Price { get; set; }
            public string AccessName { get; set; }
            public string ModelName { get; set; }
            public int Id_constr { get; set; }
            public int Id_access { get; set; }

        

            public ClientPurchaseModel(DAL.Entities.Purchase purchase, DAL.Entities.Client client, IDbRepos context)
            {
                Id = client.Id;
                FullName = client.FullName;
                Pasport = client.Pasport;
                DriverLicense = client.DriverLicense;
                Date = (DateTime)purchase.Date; 
                Id_adm = (int)purchase.Id_adm;
               // AccessName = purchase.Products.Accesouries == null ? "Нет" : purchase.Products.Accesouries.Name;
               // Price = (decimal)purchase.Products.Price;
            // ModelName = purchase.Products.Constructions == null ? "Нет" : purchase.Products.Constructions.Name;
            var prod = context.Products.GetItem(purchase.Id_product);

            if (prod.Id_acc == null)
            {
                Id_constr = (int)prod.Id_constr;
                ModelName = context.Constructions.GetItem(Id_constr).Name;
            }
                
            else
            {

                Id_access = (int)prod.Id_acc;
                AccessName = context.Accesouriess.GetItem(Id_access).Name;
            }

            }   

    }
}
