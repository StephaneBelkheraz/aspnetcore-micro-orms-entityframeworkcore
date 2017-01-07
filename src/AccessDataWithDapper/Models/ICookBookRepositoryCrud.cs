using System.Collections.Generic;
using System.Data;

namespace AccessDataWithDapper.Models
{
    public interface ICookBookRepositoryCrud
    {
        IDbConnection Connection { get; }

        void Add(Book book);
        void Delete(int id);
        IEnumerable<Book> GetAll();
        Book GetMultiple(int id);
        Book GetByID(int id);
        void Update(Book book);
    }
}