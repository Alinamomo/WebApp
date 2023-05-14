using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class ConstructionRepository : IRepository<Construction>
    {
        private CarDealershipContext db;

        public ConstructionRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Construction> GetList()
        {
            return db.Construction.ToList();
        }

        public Construction GetItem(int id)
        {
            return db.Construction.Find(id);
        }

        public void Create(Construction construction)
        {
            db.Construction.Add(construction);
        }

        public void Update(Construction construction)
        {
            db.Entry(construction).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Construction construction = db.Construction.Find(id);
            if (construction != null)
                db.Construction.Remove(construction);
        }
    }
}
