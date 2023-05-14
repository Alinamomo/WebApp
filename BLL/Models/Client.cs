using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public string Pasport { get; set; }
        public string DriverLicense { get; set; }
        public ClientModel() { }
        public ClientModel(DAL.Entities.Client client)
        {
            Id = client.Id;
            FullName = client.FullName;
            Pasport = client.Pasport;
            DriverLicense = client.DriverLicense;

        }

    }
}
