using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal.Model.Domain
{
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReciptId { get; set; }
        public int FarmerId { get; set; }
        public User FarmerUser {  get; set; }
        public int DealerId { get; set; }
        public User DealerUser { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public int QuantityRequired { get; set; }
        [Required]
        public DateTime DealDate { get; set; } = DateTime.Now;
        [Required]
        //[ForeignKey("CropId")]
        public int CropId { get; set; }
        public CropDetails CropDetails { get; set; }


    }
}
