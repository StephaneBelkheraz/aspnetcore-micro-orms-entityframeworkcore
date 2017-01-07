using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCoreStoredProcedure.Models
{
    public class CookBookContext : DbContext
    {
        public CookBookContext(DbContextOptions<CookBookContext> options) : base(options)
        {   }

        public DbSet<Book> Book { get; set; }
        public DbSet<Recipe> Recipe { get; set; }

        public IQueryable<Book> GetBooks()
        {
            return Set<Book>().FromSql("dbo.GetBooks");
        }

        public void InsertBook(string name)
        {
            string sqlRequest = $"InsertBook @name = {name}";
            int result = Database.ExecuteSqlCommand(sqlRequest);
        }

    }
}
