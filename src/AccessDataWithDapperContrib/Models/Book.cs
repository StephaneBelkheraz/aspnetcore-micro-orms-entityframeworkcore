using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace AccessDataWithDapperContrib.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}