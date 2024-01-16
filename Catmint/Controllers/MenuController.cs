using Catmint.Data;
using Catmint.Models;
using Catmint.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Catmint.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Menu> menu = _context.Dishes.ToList();
            List<Category> categ = _context.Categories.ToList();

            MenuViewModel ivm = new MenuViewModel { Menus = menu, Categories = categ};
            return View(ivm);
        }
    }
}
