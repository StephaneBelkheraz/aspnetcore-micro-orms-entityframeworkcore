
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PetaPoco;
using System.Configuration;
using PetaPoco.Providers;

namespace AccessDataWithPetaPoco.Models
{
    public class CookBookRepository : ICookBookRepository
    {
        private readonly Database _db;
        public CookBookRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            _db = new Database(connectionString, new SqlServerDatabaseProvider());
        }

        public IDatabase Connection
        {
            get
            {
                return _db;
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (IDatabase dbConnection = Connection)
            {
                return _db.Query<Book>("SELECT * FROM Book");
            }
        }

        public IGridReader GetAllMultiple()
        {
            using (IDatabase dbConnection = Connection)
            {
                return _db.QueryMultiple("SELECT * FROM Book; ");
            }

        }

        public Book GetByID(int id)
        {
            using (IDatabase dbConnection = Connection)
            {
                return _db.FirstOrDefault<Book>($"SELECT * FROM Book WHERE Id={id}");
            }
        }

        public void Add(Book book)
        {
            using (IDatabase dbConnection = Connection)
            {
                _db.Insert(book);
            }
        }

        public void Update(Book book)
        {
            using (IDatabase dbConnection = Connection)
            {
                _db.Update(book);
            }
        }

        public void Delete(Book book)
        {
            using (IDatabase dbConnection = Connection)
            {
                _db.Delete(book);
            }
        }
    }
}
