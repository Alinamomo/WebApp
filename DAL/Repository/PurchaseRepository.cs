using DAL;
using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class PurchaseRepository : IRepository<Purchase>
    {
        private CarDealershipContext db;

        public PurchaseRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Purchase> GetList()
        {
            return db.Purchase.ToList();
        }

        public Purchase GetItem(int id)
        {
            return db.Purchase.Find(id);
        }

        public void Create(Purchase purchase)
        {
            db.Purchase.Add(purchase);
        }

        public void Update(Purchase purchase)
        {
            db.Entry(purchase).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Purchase purchase = db.Purchase.Find(id);
            if (purchase != null)
                db.Purchase.Remove(purchase);
        }
    }
}
