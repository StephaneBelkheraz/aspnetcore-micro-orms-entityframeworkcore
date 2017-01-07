using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccessDataWithDapper.Models
{
    public class CookBookRepositoryCrud : ICookBookRepositoryCrud
    {
        private string _connectionString;
        private readonly IConfiguration _config;
        public CookBookRepositoryCrud(IConfiguration config)
        {
            _config = config; 
             _connectionString = _config.GetConnectionString("DbConnection");
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public IEnumerable<Book> GetAll()
        {
            using (IDbConnection db = Connection)
            {
                db.Open();

                // version requete Adhoc
                return db.Query<Book>("SELECT * FROM Book").ToList<Book>();

                // version ps
                //return db.Query<Book>("GetBooks", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using (IDbConnection db = Connection)
            {
                db.Open();

                // version requete Adhoc
                return await db.QueryAsync<Book>("SELECT * FROM Book");
            }
        }

        public Book GetByID(int id)
        {
            using (IDbConnection db = Connection)
            {
                db.Open(); 

                //string sQuery = "SELECT * FROM Book WHERE Id = @Id";
                //return db.Query<Book>(sQuery, new { Id = id }).FirstOrDefault();

                string sp = "GetBookByID";
                var parameter = new DynamicParameters();
                parameter.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                return db.Query<Book>(sp, parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Book GetMultiple(int id)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();

                // version requete Adhoc
                //string query = "SELECT * FROM Book WHERE Id=@id; SELECT * FROM Recipe WHERE IdBook=@id;";
                //var multipleResults = db.QueryMultiple(query, new { id = id });

                // version sp
                var parameter = new DynamicParameters();
                parameter.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                var multipleResults = db.QueryMultiple("GetBookRecipes", parameter, commandType: CommandType.StoredProcedure);

                var book = multipleResults.Read<Book>().SingleOrDefault();
                var recipes = multipleResults.Read<Recipe>().ToList();
                if (book != null && recipes != null)
                {
                    book.Recipes = new List<Recipe>();
                    book.Recipes.AddRange(recipes);
                }

                return book;
            }
        }

        public void Add(Book book)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();

                //string sQuery = "INSERT INTO Book (Name) VALUES(@Name)";
                //db.Execute(sQuery, book);

                var parameter = new DynamicParameters();
                parameter.Add("@name", book.Name, dbType: DbType.String, direction: ParameterDirection.Input);
                db.Execute("InsertBook", parameter, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(Book book)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Id", book.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add("@Name", book.Name, dbType: DbType.String, direction: ParameterDirection.Input);

                //string sQuery = "UPDATE Book SET Name = @Name WHERE Id = @Id";
                //db.Execute(sQuery, parameters, commandType: CommandType.Text);

                //book.Name = "New updateBook";
                //db.Execute(sQuery, book, commandType: CommandType.Text);

                string sp = "UpdateBook";
                db.Execute(sp, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = Connection)
            {
                db.Open();

                //string sQuery = "DELETE FROM Book WHERE Id = @Id";
                //db.Execute(sQuery, new { Id = id });

                var parameter = new DynamicParameters();
                parameter.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                string sp = "DeleteBook";
                db.Execute(sp, parameter, commandType: CommandType.StoredProcedure);
            }
        }

        
    }
}
