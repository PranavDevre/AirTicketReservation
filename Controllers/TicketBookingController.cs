using AIR_RESERVATION_SYSTEM_API.Repository;
using ATRWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketBookingController : ControllerBase
    {
        private readonly IFlightMaster _flightMaster;
        public TicketBookingController(IFlightMaster flightMaster)
        {
            _flightMaster = flightMaster;
        }
        [HttpGet]
        [Route("GetAvailableFlights")]
        public async Task<IActionResult> GetAvailableFlights()
        {
            var query = await _flightMaster.GetAvailableFlights();
            return Ok(query);
        }
        [HttpPost]
        [Route("bookTicket")]
        public async Task<IActionResult> BookFlight(string userName, int flightId, string source, string destination, string departuredate, string bookingdate)
        {
            var query = await _flightMaster.BookFlight(userName, flightId, source, destination, departuredate, bookingdate);
            return Ok(query);
        }

        [HttpDelete]
        [Route("cancelTicket/TicketId")]
        public async Task<IActionResult> CancelTicket(int BookingId)
        {
            var query = await _flightMaster.CancelFlight(BookingId);
            return Ok("Ticket cancelled successfully,we will refund your money with 10 working days!");
        }

        [HttpGet]
        [Route("TicketBookedHistory")]
        public async Task<ActionResult> AllDetails()
        {
            List<Ticket> flightsinfo = await _flightMaster.AllDetails();
            return Ok(flightsinfo);

        }

    }
}

