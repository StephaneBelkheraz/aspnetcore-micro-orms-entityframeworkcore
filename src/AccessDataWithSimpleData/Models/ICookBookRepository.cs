using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessDataWithSimpleData.Models
{
    public interface ICookBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> GetByID(int id);
        Task Add(Book book);
        Task Delete(int id);
        Task Update(Book book);
    }
}