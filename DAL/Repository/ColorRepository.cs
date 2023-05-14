using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    public partial class ColorRepository : IRepository<Color>
    {
        private CarDealershipContext db;

        public ColorRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Color> GetList()
        {
            return db.Color.ToList();
        }

        public Color GetItem(int id)
        {
            return db.Color.Find(id);
        }

        public void Create(Color color)
        {
            db.Color.Add(color);
        }

        public void Update(Color color)
        {
            db.Entry(color).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Color color = db.Color.Find(id);
            if (color != null)
                db.Color.Remove(color);
        }
    }
}
