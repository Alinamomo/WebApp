using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DbReposSQL: IDbRepos
    {
        private CarDealershipContext db;

        private AccesouriesRepository accesouriesRepository;
        private AdministrationRepository administrationRepository;
        private ClientRepository clientRepository;
        private ColorRepository colorRepository;
        private ConstructionRepository constructionRepository;
        private AutoModelRepository automodelRepository;
        private ModelRangeRepository modelRangeRepository;
        private PurchaseRepository purchaseRepository;
        private ProductRepository productRepository;
       

        public DbReposSQL(CarDealershipContext context)
        {
            db = context;

        }

        public IRepository<Accesouries> Accesouriess
        {
            get
            {
                if (accesouriesRepository == null)
                    accesouriesRepository = new AccesouriesRepository(db);
                return accesouriesRepository;
            }
        }

        public IRepository<Administration> Administrations
        {
            get
            {
                if (administrationRepository == null)
                    administrationRepository = new AdministrationRepository(db);
                return administrationRepository;
            }
        }

        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }
        public IRepository<Color> Colors
        {
            get
            {
                if (colorRepository == null)
                    colorRepository = new ColorRepository(db);
                return colorRepository;
            }
        }
        public IRepository<Construction> Constructions
        {
            get
            {
                if (constructionRepository == null)
                    constructionRepository = new ConstructionRepository(db);
                return constructionRepository;
            }
        }
        public IRepository<AutoModel> AutoModels
        {
            get
            {
                if (automodelRepository == null)
                    automodelRepository = new AutoModelRepository(db);
                return automodelRepository;
            }
        }
        public IRepository<ModelRange> ModelsRange
        {
            get
            {
                if (modelRangeRepository == null)
                    modelRangeRepository = new ModelRangeRepository(db);
                return modelRangeRepository;
            }
        }
        public IRepository<Purchase> Purchases
        {
            get
            {
                if (purchaseRepository == null)
                    purchaseRepository = new PurchaseRepository(db);
                return purchaseRepository;
            }
        }
      
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return (IRepository<Product>)productRepository;
            }
        }
       

        int IDbRepos.Save()
        {
            return db.SaveChanges();
        }
    }
}
