using AIR_RESERVATION_SYSTEM_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AIR_RESERVATION_SYSTEM_API.Repository
{
    public interface IAdminRepository
    {
        Task<Admin> Login(Admin adminlogin);
        Task<Flights> AddFlight(Flights flight);
        Task<Flights> DeleteFlight(int id);
        Task<List<Flights>> AllDetails();
        Task<Flights> UpdateFlight(int id, Flights flights);
        Task<List<Flights>> SearchFlight(string destinationFrom, string destinationTo);
    }
}
