using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIR_RESERVATION_SYSTEM_API.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [Required]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Numeric only not allowed")]

        public string emailId { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(13)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string confirmPassword { get; set; }


    }
}
