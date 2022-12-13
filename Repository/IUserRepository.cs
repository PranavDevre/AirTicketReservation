using AIR_RESERVATION_SYSTEM_API.Model;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Repository
{
    public interface IUserRepository
    {
        Task<int> Create(User user);
        Task<User> UserLogin(UserLogin userlogin);
    }
}
