using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Crop_Deal.Repository
{
    public class CropTypeRepo : ICropType
    {
        private readonly CropDetailDbContext _context;
        public CropTypeRepo(CropDetailDbContext context)
        {
            _context = context;
        }

        #region Add Different Types Of Crop By Admin
        public async Task<bool> AddCropTypeDetails(CropTypeDTO cropDetails)
        {
            try
            {
                if (cropDetails == null)
                {
                    return false;
                }

                var addCropDetails = new CropType
                {
                    CropTypeName = cropDetails.CropTypeName
                };
                await _context.CropTypes.AddAsync(addCropDetails);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex){
                throw;
            }
        }
        #endregion

        #region Delete the crop type
        public async Task<bool> DeleteCropTypeDetails(int cropid)
        {
            try
            {
                var cropDetails = await _context.CropTypes.FirstOrDefaultAsync(u => (u.CropTypeId == cropid));
                if (cropDetails != null)
                {
                    _context.CropTypes.Remove(cropDetails);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
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
                return await _context.CropTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get Crop Type by Id
        public async Task<CropType> GetCropTypeDetails(int croptypeid)
        {
            try
            {
                var croptypeDetails = await _context.CropTypes.FirstOrDefaultAsync(u => u.CropTypeId == croptypeid);
                return croptypeDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update the CropType
        public async Task<bool> UpdateCropTypeDetails(int croptypeid, CropTypeDTO crop)
        {
            try
            {
                if (crop == null)
                {
                    return false;
                }

                var updateCropDetails = await _context.CropTypes.FirstOrDefaultAsync(u => u.CropTypeId == croptypeid);
                if (updateCropDetails != null)
                {
                    updateCropDetails.CropTypeName = crop.CropTypeName;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

    }
}
