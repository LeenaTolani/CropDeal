using Crop_Deal.Model.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal.Model.DTO
{
    public class ReceiptDTO
    {
        [Required]
        public int FarmerId { get; set; }
        [Required] 
        public int DealerId { get; set; }
        [Required]
        public int QuantityRequired { get; set; }
        //[Required]
        //public DateTime DealDate { get; set; } 
        public int CropId { get; set; }
    }
}
