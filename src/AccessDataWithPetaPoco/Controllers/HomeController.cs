using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccessDataWithPetaPoco.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessDataWithPetaPoco.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICookBookRepository _repository;
        public HomeController(ICookBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Test GetById
            var book = _repository.GetByID(2);

            // Test Insert
            var bookToInsert = new Book
            {
                Name = "PetaPoco Unit Tests"
            };
            _repository.Add(bookToInsert);

            // Test Update
            var bookToUpdate = _repository.GetByID(5);
            bookToUpdate.Name = "Update Data Access with PetaPoco";
            _repository.Update(bookToUpdate);

            // Test Delete
            var bookToDelete = _repository.GetByID(9);
            _repository.Delete(bookToDelete);

            var books = _repository.GetAll().ToList();
            return View(books);
        }

    }
}
