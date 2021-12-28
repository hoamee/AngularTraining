using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastrure.Data
{
    public class GenericReposity<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly WarehouseContext _context;
        public GenericReposity(WarehouseContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}