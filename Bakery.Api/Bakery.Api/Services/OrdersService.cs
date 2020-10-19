using Bakery.Core.Models;
using Bakery.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task Update(Order order)
        {
            await _repository.Update(order).ConfigureAwait(false);
        }
        public async Task Create(Order order)
        {
            await _repository.Create(order).ConfigureAwait(false);
        }

        public async Task Deactivate(Order order)
        {
            order.IsActive = false;
            await _repository.Update(order).ConfigureAwait(false);
        }
    }
}
