using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class ColourModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ColourModel(DAL.Entities.Color Color)
        {
            Id = Color.Id;
            Name = Color.Name;

        }
    }
}
