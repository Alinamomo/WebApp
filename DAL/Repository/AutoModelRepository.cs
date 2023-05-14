using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class AutoModelRepository : IRepository<AutoModel>
    {
        private CarDealershipContext db;

        public AutoModelRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<AutoModel> GetList()
        {
            return db.AutoModel.ToList();
        }

        public AutoModel GetItem(int id)
        {
            return db.AutoModel.Find(id);
        }

        public void Create(AutoModel automodel)
        {
            db.AutoModel.Add(automodel);
        }

        public void Update(AutoModel automodel)
        {
            db.Entry(automodel).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            AutoModel automodel = db.AutoModel.Find(id);
            if (automodel != null)
                db.AutoModel.Remove(automodel);
        }
    }
}
