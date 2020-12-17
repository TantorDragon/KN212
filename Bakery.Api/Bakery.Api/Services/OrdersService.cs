using Bakery.Core.Models;
using Bakery.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> _repository;
        public OrdersService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetByPhoneNumber(string phoneNumber)
        {
            return await _repository.GetByPropertiesAsync(o => o.PhoneNumber == phoneNumber).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(Order order)
        {
            await _repository.UpdateAsync(order).ConfigureAwait(false);
        }
        public async Task CreateAsync(Order order)
        {
            await _repository.CreateAsync(order).ConfigureAwait(false);
        }
    }
}
