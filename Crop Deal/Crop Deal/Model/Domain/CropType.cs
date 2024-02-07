using Crop_Deal.Model.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal.Model
{
    public class CropType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CropTypeId { get; set; }
        [Required]
        [RegularExpression("^(vegetable|friuts|other)", ErrorMessage = "Invalid ")]
        public string CropTypeName { get; set;}
        public IEnumerable<CropDetails> CropDetail { get; set; }
        public IEnumerable<Subscribe> Subscribes { get; set; }

    }
}
