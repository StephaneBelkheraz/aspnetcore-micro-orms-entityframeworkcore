using System.Collections.Generic;

namespace AccessDataWithDapper.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Recipe> Recipes { get; set; }
    }
}