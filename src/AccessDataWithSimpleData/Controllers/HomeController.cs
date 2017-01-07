using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccessDataWithSimpleData.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AccessDataWithSimpleData.Controllers
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
            //// Test GetById
            //var book = await _repository.GetByID(1);

            //// Test Insert
            //var bookToInsert = new Book
            //{
            //    Name = "EF Unit Tests"
            //};
            //await _repository.Add(bookToInsert);

            //// Test Update
            //var bookToUpdate = await _repository.GetByID(3);
            //bookToUpdate.Name = "EF Unit Tests with XUnit"; 
            //await _repository.Update(bookToUpdate);

            //// Test Delete
            //await _repository.Delete(3);

            var books = await _repository.GetAll();
            return View(books);
        }

    }
}
