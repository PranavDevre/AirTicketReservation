using AIR_RESERVATION_SYSTEM_API.Model;
using ATRWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Repository
{
    public interface IFlightMaster
    {
        Task<Ticket> BookFlight(string userName, int flightId, string source, string destination, string departuredate, string bookingdate);
        Task<int> CancelFlight(int BookingId);
        Task<Flights> GetFlightDetails(int FlightID);
        Task<List<Flights>> GetAvailableFlights();

        Task<List<Ticket>> AllDetails();
    }
}
