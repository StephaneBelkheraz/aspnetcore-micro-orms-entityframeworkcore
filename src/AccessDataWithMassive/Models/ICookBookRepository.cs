using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccessDataWithMassive.Models
{
    public interface ICookBookRepository
    {
        Task<IList<dynamic>> GetAll();
        Task<dynamic> GetByID(int id);
        Task Add(dynamic book);
        Task Delete(int id);
        Task Update(dynamic book);
    }
}