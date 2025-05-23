using CarVilla.BL.Services;
using CarVilla.BL.ViewModels;
using CarVilla.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace CarVilla.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        public readonly ProductService _service;
        public ServiceController()
        {
            _service =new  ProductService();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateVM createVM)
        {
            _service.Create(createVM);
            return RedirectToAction("Table","Panel");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Table","Panel");
        }
        [HttpGet]
        public IActionResult Update(int id)
        { 
          UpdateVM updateVM = new UpdateVM();
            var exprod = _service.GetProductById(id);
            updateVM.Name = exprod.Name;    
            updateVM.Price = exprod.Price;
            updateVM.Model = exprod.Model;
            return View(updateVM);  
        }
        [HttpPost]
        public IActionResult Update(int id,UpdateVM vm)
        {
           
            _service.Update(id, vm);
            return RedirectToAction("Table","Panel");
        }
        
    }
}
