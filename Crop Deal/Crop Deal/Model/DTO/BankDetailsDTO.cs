using Crop_Deal.Model.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal.Model.DTO
{
    public class BankDetailsDTO
    {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string IfscCode { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
