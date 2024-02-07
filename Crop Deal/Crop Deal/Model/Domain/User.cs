using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crop_Deal.Model.Domain
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool ActiveStatus { get; set; } = true;
        public string Location { get; set; }
        public string Role { get; set; }
        public double Phone { get; set; }
        public BankDetails BankDetails { get; set; }
        public IEnumerable<CropDetails> CropDetails { get; set; }
        public IEnumerable<Subscribe> Subscribes { get; set; }
        public IEnumerable<Receipt> FarmerName { get; set; }
        public IEnumerable<Receipt> DealerName { get; set; }

    }
}
