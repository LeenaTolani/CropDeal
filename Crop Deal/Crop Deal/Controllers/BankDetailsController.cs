using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Crop_Deal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankDetailsController : ControllerBase
    {
        private readonly BankDetailsServices _bankDetailsServices;

        public BankDetailsController(BankDetailsServices bankDetailsServices)
        {
            _bankDetailsServices = bankDetailsServices;
        }

        #region Add Bank Detail 
        [HttpPost]
        [Route("AddBankDetails")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult> AddBankDetails(BankDetailsDTO bank) 
        {
            try
            {
                if (await _bankDetailsServices.AddBankDetails(bank) == false) 
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

        #region Update Bank Detail 
        [HttpPut]
        [Route("UpdateBankDetails/{accountid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult> UpdateBankDetails(int accountid, BankDetailsDTO bank)
        {
            try
            {
                if (await _bankDetailsServices.UpdateBankDetails(accountid, bank) == false)
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

        #region Getting all the bank details 
        [HttpGet]
        [Route("GetAllBankDetails")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<BankDetails>>> GetAllBankDetails()
        {
            try
            {
                var details = await _bankDetailsServices.GetAllBankDetails();
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

        #region Getting the bank details by id
        [HttpGet("BankDetails/{accountid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<BankDetails>> GetBankDetailsById(int accountid)
        {
            try
            {
                var userDetail = await _bankDetailsServices.GetBankDetails(accountid);
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


        #region Getting the bank details by user id
        [HttpGet("BankDetailsByUserID/{userid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<BankDetails>> GetBankDetailsByUserId(int userid)
        {
            try
            {
                var userDetail = await _bankDetailsServices.GetBankDetailsByUserId(userid);
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




        #region Delete the bank details
        [HttpDelete]
        [Route("DeleteBankDetails")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult> DeleteBankDetails(int accountid)
        {
            try
            {
                if (await _bankDetailsServices.DeleteBankDetails(accountid) == false)
                {
                    return BadRequest("UserName doesn't Exsists");
                }
                return Ok("success");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
