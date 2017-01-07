using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCoreExistingDb.Models;

namespace EntityFrameworkCoreExistingDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly CookBookContext _context;
        public HomeController(CookBookContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Book.ToList();
            return View(books);
        }
        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
