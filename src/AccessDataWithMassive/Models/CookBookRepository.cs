using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace AccessDataWithMassive.Models
{
    public class CookBookRepository : ICookBookRepository
    {
        private readonly Book _table;
        public CookBookRepository()
        {
            _table = new Book();
        }
        public async Task<IList<dynamic>> GetAll()
        {
            return await _table.AllAsync();
        }

        public async Task<dynamic> GetByID(int id)
        {
            return await _table.SingleAsync($"WHERE Id={id}");
        }

        public async Task Add(dynamic book)
        {
            await _table.InsertAsync(book);
        }
        public async Task Update(dynamic book)
        {
            await _table.UpdateAsync(book, book.Id);
        }

        public async Task Delete(int id)
        {
            await _table.DeleteAsync(id);
        }

        
    }
}
