using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public partial class ClientRepository : IRepository<Client>
    {
        private CarDealershipContext db;

        public ClientRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Client> GetList()
        {
            return db.Client.ToList();
        }

        public Client GetItem(int id)
        {
            return db.Client.Find(id);
        }

        public void Create(Client client)
        {
            db.Client.Add(client);
        }

        public void Update(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client client = db.Client.Find(id);
            if (client != null)
                db.Client.Remove(client);
        }
    }
}
