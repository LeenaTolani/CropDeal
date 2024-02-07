using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal.Model.Domain
{
    public class Subscribe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscribeId { get; set; }
        [Required]
        public bool Subscriber { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("CropTypeId")]
        public int CropTypeId { get; set; }
        public CropType CropTypes { get; set; }

    }
}
