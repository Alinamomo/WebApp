﻿using DAL;
using DAL.Entities;
using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL.Repository
{
    public partial class ProductRepository : IRepository<Product>
    {
        private CarDealershipContext db;

        public ProductRepository(CarDealershipContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Product> GetList()
        {
            return db.Product.ToList();
        }

        public Product GetItem(int id)
        {
            return db.Product.Find(id);
        }

        public void Create(Product product)
        {
            db.Product.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product product = db.Product.Find(id);
            if (product != null)
                db.Product.Remove(product);
        }
    }
}
