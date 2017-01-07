using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCoreStoredProcedure.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkCoreStoredProcedure.Controllers
{
    public class HomeController : Controller
    {
        private readonly CookBookContext _context;
        public HomeController(CookBookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _context.GetBooks().ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult PostBook()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostBook(string name)
        {
            var n = Request.Form["name"].ToString();
            _context.InsertBook(name);
            return View("Index");
        }
    }
}
