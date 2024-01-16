using Catmint.Data;
using Catmint.Models;
using Catmint.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Catmint.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MainController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            List<Description> descr = _context.Descriptions.ToList();
            List<Cat> cats = _context.Cats.ToList();
            List<User> users = _context.Users.ToList();
            List<Comment> comms = _context.Comments.ToList();

            MainViewModel ivm = new MainViewModel { Descriptions = descr, Cats = cats, Users = users, Comments = comms };
            return View(ivm);
        }
    }
}
