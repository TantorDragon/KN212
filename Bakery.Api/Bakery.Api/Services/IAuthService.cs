using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public interface IAuthService
    {
        Task<string> GetToken(string login, string password);
    }
}
