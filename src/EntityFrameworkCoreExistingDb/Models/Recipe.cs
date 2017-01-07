using System;
using System.Collections.Generic;

namespace EntityFrameworkCoreExistingDb.Models
{
    public partial class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdBook { get; set; }

        public virtual Book IdBookNavigation { get; set; }
    }
}
