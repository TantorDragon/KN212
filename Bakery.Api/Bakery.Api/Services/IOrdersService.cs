using Bakery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetByPhoneNumber(string phoneNumber);
        Task<IEnumerable<Order>> GetAll();
    }
}
