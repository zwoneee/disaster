using System.ComponentModel.DataAnnotations;

namespace DoAn.Server.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string HoTen { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
