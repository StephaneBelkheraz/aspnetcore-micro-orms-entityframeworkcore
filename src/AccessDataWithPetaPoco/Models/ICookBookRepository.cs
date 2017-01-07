using System.Collections.Generic;
using System.Data;

namespace AccessDataWithPetaPoco.Models
{
    public interface ICookBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetByID(int id);
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}