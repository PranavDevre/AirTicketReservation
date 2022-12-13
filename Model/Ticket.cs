using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATRWebApplication.Models
{
    public class Ticket
    {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int BookingId { get; set; }

        [Required]
        [ForeignKey("FlightId")]
        public int FlightId { get; set; }
        public string userName { get; set; }
        public string BookingStatus { get; set; }
        public string BookingDate { get; set; }
        public string DepartureDate { get; set; }
        public string DestinationFrom { get; set; }
        public string DestinationTo { get; set; }

    }
}
