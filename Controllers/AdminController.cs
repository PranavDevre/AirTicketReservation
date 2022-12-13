using AIR_RESERVATION_SYSTEM_API.Exception;
using AIR_RESERVATION_SYSTEM_API.Logging;
using AIR_RESERVATION_SYSTEM_API.Model;
using AIR_RESERVATION_SYSTEM_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Controllers
{
    [ServiceFilter(typeof(Admin_Logger))]

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        readonly IAdminRepository _adminRepository;
        //Constructor Dependencies
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        [HttpPost]
        [Route("AdminLogin")]
        public async Task<ActionResult> AdminLogin(Admin adminlogin)
        {

            Admin admin = await _adminRepository.Login(adminlogin);
            if (admin != null)
            {
                return Ok(admin);
            }
            else throw new AdminCredentialInvalidExceptions("Username and Password Invalid");
        }
        [HttpPost]
        [Route("AddFlight")]
        public async Task<ActionResult> AddFlight(Flights flight)
        {
            var ar = await _adminRepository.AddFlight(flight);
            return Ok(ar);
        }

        [HttpDelete]
        [Route("DeleteFlight")]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            var ar = await _adminRepository.DeleteFlight(id);
            return Ok(ar);
        }


        [HttpGet]
        [Route("AllFlights")]
        public async Task<ActionResult> AllDetails()
        {
            List<Flights> flightsinfo = await _adminRepository.AllDetails();
            return Ok(flightsinfo);

        }
        [HttpPut]
        [Route("EditFlight")]
        public async Task<IActionResult> Editflight(int id, Flights flights)
        {
            var ar = await _adminRepository.UpdateFlight(id, flights);
            return Ok(ar);
        }

        [HttpGet]
        [Route("SearchFlight")]
        public async Task<ActionResult> SearchFlight(string destinationFrom, string destinationTo)
        {
            List<Flights> flights = await _adminRepository.SearchFlight(destinationFrom, destinationTo);
            return Ok(flights);
        }





    }
}
