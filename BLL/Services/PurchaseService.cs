using BLL.Interface;
using DAL;
using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PurchaseService: IPurchaseService
    {
        private IDbRepos db;

        public PurchaseService(IDbRepos repos)
        {
            db = repos;
        }

        public bool MakePurch(BLL.Models.PurchaseModel purchaseDto)
        {
            int id;
            if (purchaseDto.Id != -1)
                id = purchaseDto.Id;
            else
                id = db.Purchases.GetList().OrderByDescending(i => i.Id).FirstOrDefault() == null ? 0 : db.Purchases.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1;

            Product p = db.Products.GetItem(purchaseDto.Id_product);
            Purchase purchase = new Purchase
            {
                Id = id,
                Date = purchaseDto.Date,
                Id_client = purchaseDto.Id_client,
                Id_adm = purchaseDto.Id_adm,
                Id_product = p.Id,
                Products = p,
                Administrators = db.Administrations.GetItem(purchaseDto.Id_adm),
                Clients = db.Clients.GetItem(purchaseDto.Id_client),
                TotalAmount = p.Price
            };
            db.Purchases.Create(purchase);
            var c = db.Clients.GetItem(purchaseDto.Id_client);
            c.Id = id;
            db.Clients.Update(c);

            if (db.Save() > 0)
                return true;
            return false;
        }
    }
}
