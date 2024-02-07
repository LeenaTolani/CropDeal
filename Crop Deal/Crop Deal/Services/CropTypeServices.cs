using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Repository;

namespace Crop_Deal.Services
{
    public class CropTypeServices 
    {
        private readonly ICropType _icropType;
        public CropTypeServices(ICropType cropType) { 
            _icropType = cropType;
        }

        #region Add Different Types Of Crop By Admin
        public async Task<bool> AddCropTypeDetails(CropTypeDTO cropDetails)
        {
            try
            {
                return await _icropType.AddCropTypeDetails(cropDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete the crop type
        public async Task<bool> DeleteCropTypeDetails(int cropid)
        {
            try
            {
                return await _icropType.DeleteCropTypeDetails(cropid);
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region To Get All Types of Crops
        public async Task<IEnumerable<CropType>> GetAllCropTypeDetails()
        {
            try
            {
                return await _icropType.GetAllCropTypeDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get Crop Type by Id
        public async Task<CropType> GetCropTypeDetails(int cropid)
        {
            try
            {

                return await _icropType.GetCropTypeDetails(cropid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update the CropType
        public async Task<bool> UpdateCropTypeDetails(int cropid, CropTypeDTO cropDetails)
        {
            try
            {
                return await _icropType.UpdateCropTypeDetails(cropid, cropDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
