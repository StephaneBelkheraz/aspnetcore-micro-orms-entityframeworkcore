using System.Collections.Generic;

namespace AccessDataWithDapper.Models
{
    public interface ICookBookRepository
    {
        List<Book> GetBooks();
    }
}