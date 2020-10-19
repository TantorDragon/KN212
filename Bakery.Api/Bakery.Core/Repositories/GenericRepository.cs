using Bakery.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : Item
    {
        private DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public async Task Create(T order)
        {
            await _context.Set<T>().AddAsync(order).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(T order)
        {
            _context.Set<T>().Update(order);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetByPropertiesAsync(Expression<Func<T, bool>> properties)
        {
            return await _context.Set<T>().Where(properties).ToListAsync();
        }
    }
}
