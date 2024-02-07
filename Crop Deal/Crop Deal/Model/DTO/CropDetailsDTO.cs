using Crop_Deal.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal.Model.DTO
{
    public class CropDetailsDTO
    {
        [Required]
        public string CropName { get; set; }
        [Required]
        public double QuantityInKg { get; set; }
        [Required]
        public double PricePerKg { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int CropTypeId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
