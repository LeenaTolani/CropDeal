using System.ComponentModel.DataAnnotations;

namespace Crop_Deal.Model.DTO
{
    public class LoginDTO
    {
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
