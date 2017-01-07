using System.Collections.Generic;
using System.Data;

namespace AccessDataWithOrmLite.Models
{
    public interface ICookBookRepositoryCrud
    {
        void Add(Book book);
        void Delete(int id);
        IEnumerable<Book> GetAll();
        Book GetByID(int id);
        void Update(Book book);
    }
}