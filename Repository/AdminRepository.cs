using AIR_RESERVATION_SYSTEM_API.Context;
using AIR_RESERVATION_SYSTEM_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Repository
{
    public class AdminRepository : IAdminRepository
    {
        readonly AIRDbContext _airdbcontext;

        public AdminRepository(AIRDbContext airdbcontext)
        {
            _airdbcontext = airdbcontext;
        }

        public async Task<Admin> Login(Admin adminlogin)
        {
            var admindata = await _airdbcontext.AdminDetails.Where(x => x.adminName == adminlogin.adminName && x.adminPassword == adminlogin.adminPassword).FirstOrDefaultAsync();
            return admindata;
        }

        public async Task<Flights> AddFlight(Flights flight)
        {
            _airdbcontext.Add(flight);
            await _airdbcontext.SaveChangesAsync();
            return flight;
        }

        public async Task<Flights> DeleteFlight(int id)
        {
            var ar = await _airdbcontext.FlightsDetails.Where(x => x.FlightId == id).FirstOrDefaultAsync();
            if (ar != null)
            {
                _airdbcontext.Remove(ar);
                await _airdbcontext.SaveChangesAsync();
            }
            return ar;
        }

        public async Task<List<Flights>> AllDetails()
        {
            var flights = await _airdbcontext.FlightsDetails.ToListAsync();
            return flights;
        }

        public async Task<Flights> UpdateFlight(int id, Flights flights)
        {
            var ar = await _airdbcontext.FlightsDetails.Where(x => x.FlightId == id).FirstOrDefaultAsync();
            if (ar != null)
            {

                ar.DestinationFrom = flights.DestinationFrom;
                ar.DestinationTo = flights.DestinationTo;
                ar.FlightDate = flights.FlightDate;
                ar.DepartTime = flights.ArriveTime;
                ar.FlightClass = flights.FlightClass;
            }
            await _airdbcontext.SaveChangesAsync();
            return flights;

        }

        public async Task<List<Flights>> SearchFlight(string destinationFrom, string destinationTo)
        {
            List<Flights> flightsexist = await _airdbcontext.FlightsDetails.Where(x => x.DestinationFrom == destinationFrom && x.DestinationTo == destinationTo).ToListAsync();
            return flightsexist;
        }
    }
}
