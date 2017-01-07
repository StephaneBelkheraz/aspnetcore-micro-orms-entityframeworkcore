using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkCore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkCore.Controllers
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
    }
}
