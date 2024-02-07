using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Data;

namespace Crop_Deal.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CropTypeController : ControllerBase
    {

        private readonly CropTypeServices _cropTypeServices;
        public CropTypeController(CropTypeServices cropTypeServices)
        {
            _cropTypeServices = cropTypeServices;
        }

        #region Add Crop Type
        [HttpPost]
        [Route("AddCropTypeDetails")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> AddCropTypeDetails(CropTypeDTO cropDetails)
        {
            try
            {
                if (await _cropTypeServices.AddCropTypeDetails(cropDetails) == false)
                {
                    return BadRequest();
                }

                return Ok();
            } catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Delete the crop type
        [HttpDelete]
        [Route("DeleteCropType/{cropid}")] 
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<JsonContent>> DeleteCropTypeDetails(int cropid)
        {
            try
            {
                if (await _cropTypeServices.DeleteCropTypeDetails(cropid) == false)
                {
                    return BadRequest(new { message  = "Croptype doesn't Exsists"  });
                }
                return Ok(new { message = "success" });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region To Get All Types of Crops
        [HttpGet]
        [Route("GetAllCropTypeDetails")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<IEnumerable<CropType>>> GetAllTypeCropDetails()
        {
            var details = await _cropTypeServices.GetAllCropTypeDetails();
            if (details == null)
            {
                return BadRequest();
            }
            return Ok(details);
        }
        #endregion

        #region Get Crop Type by Id
        [HttpGet("CropTypeDetails/{cropid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<CropType>> GetCropTypeDetails(int cropid)
        {
            try
            {
                var userDetail = await _cropTypeServices.GetCropTypeDetails(cropid);
                if (userDetail == null)
                {
                    return NotFound();
                }
                return Ok(userDetail);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update the CropType
        [HttpPut]
        [Route("UpdateCropDetails/{cropid}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> UpdateCropTypeDetails(int cropid, CropTypeDTO cropDetails)
        {
            try
            {
                if (await _cropTypeServices.UpdateCropTypeDetails(cropid, cropDetails) == false)
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
    }
}
