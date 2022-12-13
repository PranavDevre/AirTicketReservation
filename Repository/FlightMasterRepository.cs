using AIR_RESERVATION_SYSTEM_API.Context;
using AIR_RESERVATION_SYSTEM_API.Model;
using ATRWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Repository
{
    public class FlightMasterRepository : IFlightMaster
    {
        private readonly AIRDbContext _airDbContext;
        public FlightMasterRepository(AIRDbContext airDbContext)
        {
            _airDbContext = airDbContext;

        }
        public async Task<Ticket> BookFlight(string userName, int flightId, string source, string destination, string departuredate, string bookingdate)
        {
            Ticket flightmaster = new Ticket();
            Flights flight = new Flights();
            flightmaster.userName = userName;
            flightmaster.FlightId = flightId; ;
            flightmaster.DestinationFrom = source;
            flightmaster.DestinationTo = destination;
            flightmaster.DepartureDate = departuredate;
            flightmaster.BookingDate = bookingdate;
            flightmaster.BookingStatus = "Booked";


            _airDbContext.FlightMaster.Add(flightmaster);
            await _airDbContext.SaveChangesAsync();
            return flightmaster;
        }


        public async Task<int> CancelFlight(int BookingId)
        {
            var ar = await _airDbContext.FlightMaster.Where(x => x.BookingId == BookingId).FirstOrDefaultAsync();
            if (ar != null)
            {
                Ticket flightmaster = new Ticket();
                _airDbContext.FlightMaster.Remove(ar);
                flightmaster.BookingStatus = "Cancelled";


            }
            await _airDbContext.SaveChangesAsync();
            return BookingId;

        }

        public async Task<Flights> GetFlightDetails(int FlightID)
        {
            var ar = await _airDbContext.FlightsDetails.Where(x => x.FlightId == FlightID).FirstOrDefaultAsync();
            return ar;
        }

        public async Task<List<Flights>> GetAvailableFlights()
        {
            var ar = await _airDbContext.FlightsDetails.ToListAsync();
            return ar;
        }

        public async Task<List<Ticket>> AllDetails()
        {
            var flightsbook = await _airDbContext.FlightMaster.ToListAsync();
            return flightsbook;

        }
    }
}
