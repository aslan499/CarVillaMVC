using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarVilla.BL.ViewModels
{
    public class UpdateVM
    {
        [Required(ErrorMessage = "Id qeyd et ")]
        public int Id { get; set; }


        [Required(ErrorMessage ="Name daxil edilmelidir")]
        public string Name { get; set; }

        [Required (ErrorMessage ="Price qeyd edilmelidir")]
        public double Price { get; set; }
        [Required(ErrorMessage ="Model qeyd edilmelidir")]
        public string Model { get; set; }

        [Required(ErrorMessage ="Anlik at nur uzunu gorek")]
        public IFormFile Image { get; set; }
    }
}
