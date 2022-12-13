using AIR_RESERVATION_SYSTEM_API.Exception;
using AIR_RESERVATION_SYSTEM_API.Model;
using AIR_RESERVATION_SYSTEM_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("RegisterUser")]

        public async Task<ActionResult> RegisterUser(User user)
        {
            var query = await _userRepository.Create(user);
            return Ok("User Register Successfully");
            ;
        }
        [HttpPost]
        [Route("UserLogin")]
        public async Task<ActionResult> UserLogin(UserLogin userlogin)
        {
            User userexist = await _userRepository.UserLogin(userlogin);
            if (userexist != null)
            {
                return Ok(userexist);
            }
            else throw new AdminCredentialInvalidExceptions("Username and Password Invalid");
        }
    }
}
