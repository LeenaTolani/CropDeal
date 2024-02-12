using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Crop_Deal.Repository
{
    public class CropDetailsRepo : ICropDetails
    {
        private readonly CropDetailDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public CropDetailsRepo(CropDetailDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        #region Adding Crop by the farmer to sell
        public async Task<bool> AddCrop(PostCropDetailsDTO crop)
        {
            try
            {
                //if (crop == null)
                //{
                //  return false;
                //}

                if (crop != null && crop.CropImage != null)
                {
                    string? uniqueFilename = null;
                    string ImageUploadedFolder = Path.Combine(_environment.WebRootPath, "CropsImages");
                    uniqueFilename = Guid.NewGuid().ToString() + "_" + crop.CropImage.FileName;
                    string filePath = Path.Combine(ImageUploadedFolder, uniqueFilename);
                    using (var fileStram = new FileStream(filePath, FileMode.Create))
                    {
                        crop.CropImage.CopyTo(fileStram);
                    }

                    var addCropDetails = new CropDetails
                    {
                        CropName = crop.CropName,
                        QuantityInKg = crop.QuantityInKg,
                        PricePerKg = crop.PricePerKg,
                        Location = crop.Location,
                        CropTypeId = crop.CropTypeId,
                        UserId = crop.UserId,
                        CropImageUrl = "CropsImages/"+ uniqueFilename

                    };
                    await _context.CropDetails.AddAsync(addCropDetails);
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

        #region Update the crop details
        public async Task<bool> UpdateCrop(int cropId,CropDetailsDTO crop)
        {
            try
            {
                if (crop == null)
                {
                    return false;
                }

                var cropDetails = await _context.CropDetails.FirstOrDefaultAsync(u => u.CropId == cropId);
                if (cropDetails != null)
                {
                    cropDetails.CropName = crop.CropName;
                    cropDetails.QuantityInKg = crop.QuantityInKg;
                    cropDetails.PricePerKg = crop.PricePerKg;
                    cropDetails.Location = crop.Location;
                    cropDetails.CropTypeId = crop.CropTypeId;
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


        #region Get All Crops 
        public async Task<IEnumerable<CropDetails>> GetAllCropsDetails()
        {
            try
            {
                return await _context.CropDetails.ToListAsync();
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
                var cropDetails = await _context.CropDetails.FirstOrDefaultAsync(u => u.CropId == cropid);
                return cropDetails;
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
                var cropDetails = await _context.CropDetails.FirstOrDefaultAsync(u => (u.CropId == cropid));
                if (cropDetails != null)
                {
                    _context.CropDetails.Remove(cropDetails);
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

        #region Search the crop by its name
        public async Task<IEnumerable<CropDetails>> SearchBar(string searchTerm)
        {
            try
            {

                var cropsNames = await _context.CropDetails
                    .Include(ct => ct.CropType)
                    .Where(c => c.CropName.ToLower().Contains(searchTerm.ToLower()) 
                    &&  c.QuantityInKg >0)
                    .ToListAsync();
                return cropsNames;
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
                return await _context.CropDetails.Include(c=> c.CropType).FirstOrDefaultAsync(a => a.CropId == cropid);
            } catch (Exception ex)
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
                return await _context.CropDetails
                    .Include(cd => cd.CropType)
                    .Where(cd => cd.UserId == userId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get all crops with crop type details
        public async Task<IEnumerable<CropDetails>> getAllCropsWithCropType()
        {
            try
            {
                return await _context.CropDetails.Include(ct => ct.CropType)
                    .Where(c=> c.QuantityInKg >0)
                    .ToListAsync();
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}