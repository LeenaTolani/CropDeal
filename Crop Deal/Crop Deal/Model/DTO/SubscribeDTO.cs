using Crop_Deal.Model.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crop_Deal.Model.DTO
{
    public class SubscribeDTO
    {
        public bool Subscriber { get; set; }
        public int UserId { get; set; }
        public int CropTypeId { get; set; }
    }
}
