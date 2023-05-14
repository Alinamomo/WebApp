using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IDbCrud
    {
        List<AdministrationModel> GetAllAdministrations();

        List<AccesouriesModel> GetAllAccesouries();
        List<ClientModel> GetAllClients();
        List<ColourModel> GetAllColours();
        List<ConstructionModel> GetAllConstructions();
        List<AutoModelModel> GetAllAutoModels();
        List<ModelRangeModel> GetAllModelRanges();
        List<PurchaseModel> GetAllPurchases();
        List<ProductModel> GetAllProducts();

        List<ClientPurchaseModel> GetAllClientPurchaseModels();
        void CreateClientPurch(ClientPurchaseModel clientPurchaseModel);
     
       

        //OrderModel GetOrder(int id);
        void CreatePurch(PurchaseModel p);
        int CreateClient(ClientModel c);
    //    int CreateAdministration(AdministrationModel administration);
        bool Save();
        void UpdatePurch(PurchaseModel p);
        void UpdateConstruction(ConstructionModel c);
    }
}
