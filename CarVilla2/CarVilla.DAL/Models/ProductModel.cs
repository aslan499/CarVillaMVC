using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVilla.DAL.Models
{
    public   class ProductModel:BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }   

        public string? ImgUrl { get; set; }

    }
}
