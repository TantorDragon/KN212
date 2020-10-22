using Bakery.Core.Models;
using Bakery.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IRepository<Product> _repository;
        public ProductsService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(Product product)
        {
            await _repository.DeleteAsync(product).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Product product)
        {
            await _repository.UpdateAsync(product).ConfigureAwait(false);
        }
    }
}
