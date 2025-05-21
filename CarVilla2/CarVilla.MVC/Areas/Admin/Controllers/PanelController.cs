using CarVilla.DAL.Contexts;
using CarVilla.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarVilla.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PanelController : Controller
    {
        private readonly AppDbContext _context;
        public PanelController()
        {
            _context = new AppDbContext();

        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Table()
        {
            List<ProductModel> list = _context.productModels.ToList();
            return View(list);
        }
    }
}
