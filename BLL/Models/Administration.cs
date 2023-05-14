using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class AdministrationModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int Experience { get; set; }
        public DateTime Date { get; set; }

        public AdministrationModel(DAL.Entities.Administration adm)
        {
            Id = adm.Id;
            FullName = adm.FullName;
            Experience = (int)adm.Experience;
            Date = (DateTime)adm.Date;

        }
        public AdministrationModel() { }
    }
}
