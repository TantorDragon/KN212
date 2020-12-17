using Bakery.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetByPhoneNumber(string phoneNumber);

        Task<IEnumerable<Order>> GetAllAsync();

        Task UpdateAsync(Order order);

        Task CreateAsync(Order order);
    }
}
