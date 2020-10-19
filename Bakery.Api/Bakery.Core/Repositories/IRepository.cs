using Bakery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bakery.Core.Repositories
{
    public interface IRepository<T> where T : Item
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByPropertiesAsync(Expression<Func<T, bool>> filters);
        Task Create(T item);
        Task Update(T item);
    }
}
