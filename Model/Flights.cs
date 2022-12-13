using System.ComponentModel.DataAnnotations;

namespace AIR_RESERVATION_SYSTEM_API.Model
{
    public class Flights
    {
        [Key]
        [Required]
        public int FlightId { get; set; }
        [Required]
        public string DestinationFrom { get; set; }
        [Required]
        public string DestinationTo { get; set; }
        [Required]
        public string FlightDate { get; set; }
        [Required]
        public string DepartTime { get; set; }
        [Required]
        public string ArriveTime { get; set; }
        [Required]
        public string FlightClass { get; set; }

    }
}
