using Bakery.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);
    }
}
