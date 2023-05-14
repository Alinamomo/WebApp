using BLL.Interface;
using BLL.Models;
using DAL.Entities;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdministrationService: IAdministration
    {
        private IDbRepos db;
        public AdministrationService(IDbRepos repos)
        {
            db = repos;
        }


        public int CreateAdministration(AdministrationModel administration)
        {
            Administration a = new Administration
            {
                Date = administration.Date,
                FullName = administration.FullName,
                Experience = administration.Experience
            };

            db.Administrations.Create(a);
            db.Save();
            a = db.Administrations.GetList().OrderByDescending(i => i.Id).FirstOrDefault();
            return a.Id;
        }
        public AdministrationModel GetAdministration(int id)
        {
            return new AdministrationModel(db.Administrations.GetItem(id));
        }

    }
}
