using System.Collections.Generic;

namespace AccessDataWithOrmLite.Models
{
    public interface ICookBookRepository
    {
        List<Book> GetBooks();
    }
}