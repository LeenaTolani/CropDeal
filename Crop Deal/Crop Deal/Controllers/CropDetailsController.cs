using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Repository;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Crop_Deal.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CropDetailsController : ControllerBase
    {

        public readonly CropDetailsServices _cropDetailsService;
        public CropDetailsController(CropDetailsServices cropDetailsService)
        {
            _cropDetailsService = cropDetailsService;
        }

        #region Add Crop 
        [Authorize(Roles = "farmer")]
        [HttpPost]
        [Route("AddCropDetails")]
        public async Task<ActionResult> AddCrop(CropDetailsDTO crop)
        {
            try
            {
                if (await _cropDetailsService.AddCrop(crop) == false)
                {
                    return BadRequest();
                }

                return Ok();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete Crop 
        [HttpDelete]
        [Route("DeleteCropDetails")]
        [Authorize(Roles = "farmer,admin")]
        public async Task<ActionResult> DeleteCropDetails(int cropid)
        {
            try
            {
                if (await _cropDetailsService.DeleteCropDetails(cropid) == false)
                {
                    return BadRequest("Crop doesn't Exsists");
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All Crops 
        [HttpGet]
        [Route("GetAllCropDetails")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllCropsDetails()
        {
            try
            {
                var details = await _cropDetailsService.GetAllCropsDetails();
                if (details == null)
                {
                    return BadRequest();
                }
                return Ok(details);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Get Details of Particular Id
        [HttpGet("CropDetails/{cropid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<CropDetails>> GetCropDetailsById(int cropid)
        {
            try
            {
                var cropDetail = await _cropDetailsService.GetCropDetailsById(cropid);
                if (cropDetail == null)
                {
                    return NotFound();
                }
                return Ok(cropDetail);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Update the crop details
        [HttpPut]
        [Route("UpdateCropDetails/{cropId}")]
        [Authorize(Roles = "farmer")]
        public async Task<ActionResult> UpdateCrop(int cropId, CropDetailsDTO crop)
        {
            try
            {
                if (await _cropDetailsService.UpdateCrop(cropId, crop) == false)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get Crop by Name
        [HttpGet("SearchNyName/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<CropDetails>>> SearchBar(string searchTerm)
        {
            try
            {
                var cropNames = await _cropDetailsService.SearchBar(searchTerm);
                if (cropNames == null)
                {
                    return BadRequest(cropNames);
                }
                return Ok(cropNames);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion



        #region CropType details along with Crop Details
        [HttpGet("croptype/{cropid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<Task<CropDetails>>> GetCropTypeOfCropDetails(int cropid)
        {
            try
            {
                var details = await _cropDetailsService.GetCropTypeOfCropDetails(cropid);
                return Ok(details);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region  Get Crop Details By User Id
        [HttpGet("User/{userId}")]
        [Authorize(Roles = "farmer")]
        public async Task<IActionResult> GetCropDetailsByUserId(int userId)
        {
            try
            {
                var cropDetails = await _cropDetailsService.GetCropDetailsByUserIdAsync(userId);

                if (cropDetails == null)
                {
                    return NotFound();
                }

                return Ok(cropDetails);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion


        #region Get all crops with crop type details

        [HttpGet("User/CropType")]
        public async Task<IActionResult> getAllCropsWithCropType()
        {
            try
            {
                var result = await _cropDetailsService.getAllCropsWithCropType();
                if (result == null)
                    return BadRequest();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}