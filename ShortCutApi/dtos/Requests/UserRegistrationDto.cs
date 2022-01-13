using System.ComponentModel.DataAnnotations;

namespace ShortCutApi.dtos.Requests
{
    public class UserRegistrationDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}