using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Interface
{
    public interface ICropDetails
    {
        Task<bool> AddCrop(CropDetailsDTO crop);
        Task<bool> UpdateCrop(int cropId, CropDetailsDTO crop);
        Task<CropDetails> GetCropDetailsById(int cropid);
        Task<IEnumerable<CropDetails>> GetAllCropsDetails();
        Task<bool> DeleteCropDetails(int cropid);
        Task<IEnumerable<CropDetails>> SearchBar(string searchTerm);

        Task<CropDetails> GetCropTypeOfCropDetails(int cropid);
        Task<IEnumerable<CropDetails>> GetCropDetailsByUserIdAsync(int userId);

        Task<IEnumerable<CropDetails>> getAllCropsWithCropType();

    }
}
