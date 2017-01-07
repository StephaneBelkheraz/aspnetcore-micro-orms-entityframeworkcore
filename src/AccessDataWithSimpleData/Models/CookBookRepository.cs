using System.Collections.Generic;
using Simple.Data;
using System.Threading.Tasks;

namespace AccessDataWithSimpleData.Models
{
    public class CookBookRepository : ICookBookRepository
    {
        private readonly dynamic _db;
        public CookBookRepository()
        {
            _db = Database.OpenConnection(Startup.Configuration["connectionStrings:DbConnection"]);
        }

        public dynamic Connection
        {
            get
            {
                return _db;
            }
        }

        public async Task<List<Book>> GetAll()
        {
            //return await _db["Book"].All().ToList<Book>();
            return await _db.Book.All().ToList<Book>();
        }

        public async Task<Book> GetByID(int id)
        {
            return await _db.Book.Find(_db.Book.Id == id);
            //return await _db.Book.Get(id).Cast<Book>();
        }

        public async Task Add(Book book)
        {
            await _db.Book.Insert(book);
        }

        public async Task Update(Book book)
        {
            await _db.Book.UpdateById(Id: book.Id, Name: book.Name);
        }

        public async Task Delete(int id)
        {
            await _db.Book.DeleteById(id);
        }

        
    }
}
