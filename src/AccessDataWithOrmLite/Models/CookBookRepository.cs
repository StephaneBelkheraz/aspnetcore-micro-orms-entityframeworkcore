using System.Collections.Generic;
using System.Data;
using System.Linq;
using ServiceStack.OrmLite;

namespace AccessDataWithOrmLite.Models
{
    public class CookBookRepository : ICookBookRepository
    {
        private readonly IDbConnection _db;
        public CookBookRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Book> GetBooks()
        {
            //string sqlCommand = "SELECT Id, Name FROM dbo.Book";
            //return _db.SqlList<Book>(sqlCommand).ToList();

            string sqlCommand = "GetBooks";
            return _db.SqlList<Book>(sqlCommand).ToList();
        }
    }

    
}
