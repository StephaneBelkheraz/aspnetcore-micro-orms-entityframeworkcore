using AccessDataWithDapperContrib.Models;
using System.Collections.Generic;

namespace AccessDataWithDapperContrib.Services
{
    public interface ICookBookRepository
    {
        void Add(Book book);
        void AddMultiple(List<Book> books);
        void Delete(Book book);
        void DeleteAll();
        IEnumerable<Book> GetAll();
        Book GetByID(int id);
        void Update(Book book);
    }
}