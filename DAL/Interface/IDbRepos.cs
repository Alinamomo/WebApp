using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IDbRepos
    {
        IRepository<Accesouries> Accesouriess { get; }
        IRepository<Administration> Administrations { get; }
        IRepository<Client> Clients { get; }
        IRepository<Color> Colors { get; }
        IRepository<Construction> Constructions { get; }

        IRepository<AutoModel> AutoModels { get; }

        IRepository<ModelRange> ModelsRange { get; }
        IRepository<Product> Products { get; }
        
        IRepository<Purchase> Purchases { get; }
       
        int Save();
    }
}
