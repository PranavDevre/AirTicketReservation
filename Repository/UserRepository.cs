using AIR_RESERVATION_SYSTEM_API.Context;
using AIR_RESERVATION_SYSTEM_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly AIRDbContext _adminDbContext;

        public UserRepository(AIRDbContext adminDbContext)
        {
            _adminDbContext = adminDbContext;
        }
        public async Task<int> Create(User user)
        {
            _adminDbContext.UserDetails.Add(user);
            return await _adminDbContext.SaveChangesAsync();

        }


        public async Task<User> UserLogin(UserLogin userlogin)
        {
            var userdata = await _adminDbContext.UserDetails.Where(x => x.emailId == userlogin.emailId && x.Password == userlogin.Password).FirstOrDefaultAsync();
            return userdata;
        }
    }
}
;