using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Interface
{
    public interface ICropType
    {
        Task<bool> AddCropTypeDetails(CropTypeDTO cropDetails);
        Task<bool> UpdateCropTypeDetails(int cropid, CropTypeDTO crop);
        Task<CropType> GetCropTypeDetails(int cropid);
        Task<IEnumerable<CropType>> GetAllCropTypeDetails();
        Task<bool> DeleteCropTypeDetails(int cropid);
    }
}
