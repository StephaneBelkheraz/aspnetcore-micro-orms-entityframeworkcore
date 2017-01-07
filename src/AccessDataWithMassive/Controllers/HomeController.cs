using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccessDataWithMassive.Models;
using System.Dynamic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessDataWithMassive.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICookBookRepository _repository;
        public HomeController(ICookBookRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Test GetById
            var book = await _repository.GetByID(2);

            // Test Insert
            dynamic bookToInsert = new ExpandoObject();
            bookToInsert.Name = "Data Access with MASSIVE - Inserting";
            await _repository.Add(bookToInsert);

            // Test Update
            var bookToUpdate = new { Id = 8, Name = "Data Access with MASSIVE - Updating" };
            await _repository.Update(bookToUpdate);

            // Test Delete
            await _repository.Delete(8);

            var books = await _repository.GetAll();
            return View(books);
        }

    }
}
