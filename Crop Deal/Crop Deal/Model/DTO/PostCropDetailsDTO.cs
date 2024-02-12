using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal.Model.DTO
{
    public class PostCropDetailsDTO
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
        [Required]
        public IFormFile CropImage { get; set; }
    }
}
