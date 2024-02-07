using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal.Model.Domain
{
    public class CropDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CropId { get; set; }
        [Required]
        public string CropName { get; set; }
        [Required]
        public double QuantityInKg { get; set; }
        [Required]
        public double PricePerKg { get; set; }
        [Required]
        public string Location { get; set; }
        public IEnumerable<Receipt> Receipt { get; set; }
        [ForeignKey("CropTypeId")]
        public int CropTypeId { get; set; } 
        public CropType CropType { get; set; } // Navigation Property
        [ForeignKey("Farmer")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
