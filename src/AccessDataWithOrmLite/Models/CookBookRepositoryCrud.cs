using ServiceStack.OrmLite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ServiceStack.Data;
using System;

namespace AccessDataWithOrmLite.Models
{
    public class CookBookRepositoryCrud : ICookBookRepositoryCrud
    {
        #region Option 1, see Startup.cs for Option 1 configuration
        //private string _connectionString;
        //private readonly IConfiguration _config;
        //private readonly OrmLiteConnectionFactory _dbFactory;
        //public CookBookRepositoryCrud(IConfiguration config)
        //{
        //    _config = config;
        //    _connectionString = _config.GetConnectionString("DbConnection");
        //    _dbFactory = new OrmLiteConnectionFactory(_connectionString, SqlServer2012Dialect.Provider);
        //}

        //public IDbConnection Connection
        //{
        //    get
        //    {
        //        return _dbFactory;
        //    }
        //}
        #endregion

        #region option 2, see see Startup.cs for Option 2 configuration

        //private readonly IDbConnection _dbFactory;
        //public CookBookRepositoryCrud(IDbConnection dbFactory)
        //{
        //    _dbFactory = dbFactory;
        //}

        //public IDbConnection Connection
        //{
        //    get
        //    {
        //        return _dbFactory;
        //    }
        //}

        #endregion

        #region option 3, see see Startup.cs for Option 3 configuration

        private readonly IDbConnectionFactory _dbFactory;
        public CookBookRepositoryCrud()
        {
            _dbFactory = new OrmLiteConnectionFactory(
                Startup.Configuration["connectionStrings:DbConnection"], 
                SqlServer2012Dialect.Provider);
        }

        #endregion




        public IEnumerable<Book> GetAll()
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                return dbConnection.Select<Book>();
                //return await dbConnection.SelectAsync<Book>();
            }
        }

        public Book GetByID(int id)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                dbConnection.Open();
                return dbConnection.Select<Book>(s => s.Id == id).FirstOrDefault();
                //return await dbConnection.SelectAsync<Book>(s => s.Id == id).FirstOrDefault();
            }
        }

        public void Add(Book book)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                dbConnection.Open();
                dbConnection.Insert<Book>(book);
                // await dbConnection.InsertAsync<Book>(book);
            }
        }

        public void Update(Book book)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                dbConnection.Open();
                dbConnection.UpdateOnly<Book>(
                    book,
                    onlyFields: f => f.Name == book.Name,
                    where: s => s.Id == book.Id);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = _dbFactory.OpenDbConnection())
            {
                dbConnection.Open();
                dbConnection.Delete<Book>(s => s.Id == id);
                //await dbConnection.DeleteAsync<Book>(s => s.Id == id);
            }
        }

        
    }
}
