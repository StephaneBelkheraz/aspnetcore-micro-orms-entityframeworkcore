using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace AccessDataWithDapper.Models
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
            //return _db.Query<Book>(sqlCommand, commandType: CommandType.Text).ToList();

            string sqlCommand = "GetBooks";
            return _db.Query<Book>(sqlCommand, commandType: CommandType.StoredProcedure).ToList();
        }
    }

    
}
