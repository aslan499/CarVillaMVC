using CarVilla.DAL.Contexts;
using CarVilla.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarVilla.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController()
        {
            _context= new AppDbContext();   
        }
        public IActionResult Index()
        {
            List<ProductModel> list = _context.productModels.ToList();
            return View(list);
        }

    }
}
