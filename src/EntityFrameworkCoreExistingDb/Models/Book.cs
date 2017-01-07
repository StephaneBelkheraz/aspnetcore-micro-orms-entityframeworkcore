using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreExistingDb.Models
{
    public partial class Book
    {
        public Book()
        {
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
