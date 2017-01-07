using System.Collections.Generic;
using System.Data;
using Dapper.Contrib.Extensions;
using AccessDataWithDapperContrib.Models;
using System.Data.SqlClient;

namespace AccessDataWithDapperContrib.Services
{
    public class CookBookRepository : ICookBookRepository
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(Startup.Configuration["connectionStrings:DbConnection"]);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                return db.GetAll<Book>();
            }
        }

        public Book GetByID(int id)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                return db.Get<Book>(id);
            }
        }

        public void Add(Book book)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                db.Insert(book);
            }
        }

        public void AddMultiple(List<Book> books)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                db.Insert(books);
            }
        }

        public void Update(Book book)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                db.Update(book);
            }
        }

        public void Delete(Book book)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                db.Delete(book);
            }
        }

        public void DeleteAll()
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                db.DeleteAll<Book>();
            }
        }
    }

    
}
