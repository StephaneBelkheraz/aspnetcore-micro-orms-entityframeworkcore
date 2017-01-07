using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccessDataWithOrmLite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessDataWithOrmLite.Controllers
{
    public class HomeController : Controller
    {
        #region Example with CookBookRepository

        //private readonly ICookBookRepository _repository;
        //public HomeController(ICookBookRepository repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var books = _repository.GetBooks().ToList();
        //    return View(books);
        //}

        #endregion

        #region Example with CookBookRepositoryCrud

        private readonly ICookBookRepositoryCrud _repository;
        public HomeController(ICookBookRepositoryCrud repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _repository.GetAll().ToList();
            return View(books);
        }

        #endregion
    }
}
