using Massive;

namespace AccessDataWithMassive.Models
{
    public class Book : DynamicModel
    {
        public Book():base("DbConnection", "Book","Id") { }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}