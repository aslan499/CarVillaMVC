using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVilla.BL.ViewModels
{
    public class CreateVM
    {
        
     
        [Required(ErrorMessage ="Name yaz qaqas")]
        public string Name { get; set; }

        [Required (ErrorMessage ="Price yaz ")]
        public double Price { get; set; }

        [Required (ErrorMessage ="Model qeyd et")]
        public string Model { get; set; }

        [Required(ErrorMessage =" Seklin cek ")]
        public IFormFile Image { get; set; }
    }
}
