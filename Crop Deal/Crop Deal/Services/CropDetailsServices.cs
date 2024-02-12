using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Repository;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Services
{
    public class CropDetailsServices
    {
        private readonly ICropDetails _cropDetailsRepo;
        public CropDetailsServices(ICropDetails cropDetailsRepo)
        {
            _cropDetailsRepo = cropDetailsRepo;
        }

        #region Adding Crop by the farmer to sell
        public async Task<bool> AddCrop(PostCropDetailsDTO crop)
        {
            try
            {
                return await _cropDetailsRepo.AddCrop(crop);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Deleting the Crop by the farmer and admin
        public async Task<bool> DeleteCropDetails(int cropid)
        {
            try
            {
                return await _cropDetailsRepo.DeleteCropDetails(cropid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Get All Crops 
        public async Task<IEnumerable<CropDetails>> GetAllCropsDetails()
        {
            try
            {
                return await _cropDetailsRepo.GetAllCropsDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Get Details of Particular Id
        public async Task<CropDetails> GetCropDetailsById(int cropid)
        {
            try
            {
                return await _cropDetailsRepo.GetCropDetailsById(cropid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Update the crop details
        public async Task<bool> UpdateCrop(int cropId, CropDetailsDTO crop)
        {
            try
            {
                return await _cropDetailsRepo.UpdateCrop(cropId, crop);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Search the crop by its name
        public async Task<IEnumerable<CropDetails>> SearchBar(string searchTerm)
        {
            try
            {
                return await _cropDetailsRepo.SearchBar(searchTerm);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region CropType details along with Crop Details
        public async Task<CropDetails> GetCropTypeOfCropDetails(int cropid)
        {
            try
            {
                return await _cropDetailsRepo.GetCropTypeOfCropDetails(cropid);
            }catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region  Get Crop Details By User Id
        public async Task<IEnumerable<CropDetails>> GetCropDetailsByUserIdAsync(int userId)
        {
            try
            {
                return await _cropDetailsRepo.GetCropDetailsByUserIdAsync(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Get all crops with crop type details
        public async Task<IEnumerable<CropDetails>> getAllCropsWithCropType()
        {
            try
            {
                return await _cropDetailsRepo.getAllCropsWithCropType();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}