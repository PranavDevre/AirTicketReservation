using System.ComponentModel.DataAnnotations;

namespace AIR_RESERVATION_SYSTEM_API.Model
{
    public class Admin
    {
        [Required]
        public string adminName { get; set; }
        [Required]
        public string adminPassword { get; set; }
    }

}
