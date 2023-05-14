using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace DAL.Repository
{
    public partial class AdministrationRepository : IRepository<Administration>
    {
        private CarDealershipContext db;

        public AdministrationRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Administration> GetList()
        {
            return db.Administration.ToList();
        }

        public Administration GetItem(int id)
        {
            return db.Administration.Find(id);
        }

        public void Create(Administration administration)
        {
            db.Administration.Add(administration);
        }

        public void Update(Administration administration)
        {
            db.Entry(administration).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Administration administration = db.Administration.Find(id);
            if (administration != null)
                db.Administration.Remove(administration);
        }
    }
}
