using BLL.Models;
using DAL;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;
using DAL.Entities;

namespace BLL
{
    public class DBDataOperation : IDbCrud
    {
        private IDbRepos db;
        public DBDataOperation(IDbRepos repos)
        {
            db = repos;
        }

        public DBDataOperation()
        {
        }

        public List<AccesouriesModel> GetAllAccesouries()
        {
            return db.Accesouriess.GetList().Select(i => new Models.AccesouriesModel(i)).ToList();
        }

        public List<AdministrationModel> GetAllAdministrations()
        {
            return db.Administrations.GetList().Select(i => new Models.AdministrationModel(i)).ToList();
        }

        public List<ClientModel> GetAllClients()
        {
            return db.Clients.GetList().Select(i => new Models.ClientModel(i)).ToList();
        }

        public List<ColourModel> GelAllColors()
        {
            return db.Colors.GetList().Select(i => new Models.ColourModel(i)).ToList();
        }

        public List<ConstructionModel> GetAllConstructions()
        {
            return db.Constructions.GetList().Select(i => new ConstructionModel(i, db)).ToList();
        }

        public List<Models.AutoModelModel> GetAllAutoModels()
        {
            return db.AutoModels.GetList().Select(i => new Models.AutoModelModel(i)).ToList();
        }

        public List<ModelRangeModel> GetAllModelRanges()
        {
            return db.ModelsRange.GetList().Select(i => new Models.ModelRangeModel(i)).ToList();
        }


        public List<PurchaseModel> GetAllPurchases()
        {
            return db.Purchases.GetList().Select(i => new Models.PurchaseModel(i)).ToList();
        }

        public List<ProductModel> GetAllProducts()
        {
            return db.Products.GetList().Select(i => new Models.ProductModel(i)).ToList();
        }


        public List<ColourModel> GetAllColours()
        {
            return db.Colors.GetList().Select(i => new Models.ColourModel(i)).ToList();
        }

        public List<ClientPurchaseModel> GetAllClientPurchaseModels()
        {
            List<Client> clients = db.Clients.GetList();
            List<Purchase> purchases = db.Purchases.GetList();
            List<ClientPurchaseModel> cp = new List<ClientPurchaseModel>();
                for (int i = 0; i < clients.Count; ++i)
                {
                cp.Add(new ClientPurchaseModel(purchases[i], clients[i], db));
                
                }
            return cp;
        }


        public void CreatePurch(PurchaseModel p)
        {
            Client c = db.Clients.GetList().Where(i => i.Id == p.Id_client).FirstOrDefault();
            Administration a = db.Administrations.GetList().Where(i => i.Id == p.Id_adm).FirstOrDefault();
            

            db.Purchases.Create(new Purchase() { Id = p.Id, Id_client = p.Id_client, Date = p.Date, Id_adm = p.Id_adm, Clients = c, Administrators = a});
            Save();

        }

        
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

        public void UpdatePurch(PurchaseModel p)
        {
            Purchase pu = db.Purchases.GetItem(p.Id);
            pu.Id_adm = p.Id_adm;
            pu.Id_client = p.Id_client;
            pu.Date = p.Date;
            Save();
        }

        public void UpdateConstruction(ConstructionModel c)
        {
            Construction con = db.Constructions.GetItem(c.Id);
            con.InStock = c.InStock < 0 ? 0 : c.InStock;

            Save();
        }
        public void DeletePurch(int id)
        {
            Purchase o = db.Purchases.GetItem(id);
            if (o != null)
            {
                db.Purchases.Delete(id);
                Save();
            }
        }

        public int CreateClient(ClientModel c)
        {
            Client client = new Client
            {
                FullName = c.FullName,
                DriverLicense = c.DriverLicense,
                Pasport = c.Pasport,
                Id = db.Clients.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1
            };

            db.Clients.Create(client);
            Save();

            return client.Id;
        }

        public void CreateClientPurch(ClientPurchaseModel clientPurchaseModel)
        {
            Client client = new Client
            {

                FullName = clientPurchaseModel.FullName,
                DriverLicense = clientPurchaseModel.DriverLicense,
                Pasport = clientPurchaseModel.Pasport,
                Id = db.Clients.GetList().OrderByDescending(i => i.Id).FirstOrDefault().Id + 1
               
            };
            db.Clients.Create(client);
            Save();

            Purchase purchase = new Purchase
            {
                Id = client.Id,
                Date = (DateTime)clientPurchaseModel.Date,
                Id_adm = (int)clientPurchaseModel.Id_adm,
                Id_product = (int)clientPurchaseModel.Id_product,
                TotalAmount = (int)clientPurchaseModel.Price
                
             };
            db.Purchases.Create(purchase);
            Save();
        }
    }
}