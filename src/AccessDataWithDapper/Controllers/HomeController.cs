using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccessDataWithDapper.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessDataWithDapper.Controllers
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
            // Test GetById
            var book = _repository.GetByID(2);

            // Test GetMultiple
            var bookRecipes = _repository.GetMultiple(1);

            // Test Insert
            var bookToInsert = new Book
            {
                Name = "Dapper xUnit Tests 2"
            };
            _repository.Add(bookToInsert);

            // Test Update
            var bookToUpdate = _repository.GetByID(12);
            bookToUpdate.Name = "Last Update Data Access with Dapper 2";
            _repository.Update(bookToUpdate);

            // Test Delete
            var bookToDelete = _repository.GetByID(15);
            _repository.Delete(bookToDelete.Id);

            var books = _repository.GetAll();
            return View(books);
        }

        #endregion
    }
}
