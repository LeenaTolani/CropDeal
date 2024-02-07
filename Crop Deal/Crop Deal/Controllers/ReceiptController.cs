using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : Controller
    {
        private readonly ReceiptServices _receiptServices;
        public ReceiptController(ReceiptServices receiptServices)
        {
            _receiptServices = receiptServices;
        }

        #region Get All the Receipts
        [HttpGet]
        [Route("GetAllReceipt")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetAllReceipts()
        {
            try
            {
                var allReceipts  = await  _receiptServices.GetAllReceipts();
                if(allReceipts == null)
                {
                    return BadRequest("No Successful Payment is done");
                }
                return Ok(allReceipts);
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All the Receipts with all details
        [HttpGet]
        [Route("GetAllReceiptWithCropAndUser")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetAllReceiptsWithCropAndUser()
        {
            try
            {
                var allReceipts = await _receiptServices.GetAllReceiptsWithCropAndUser();
                if (allReceipts == null)
                {
                    return BadRequest();
                }
                return Ok(allReceipts);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion



        #region Get Receipt By Id
        [HttpGet]
        [Route("GetReciptById/{id}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<Receipt>> GetReceiptByID(int id)
        {
            try
            {
                var getReceipt = await _receiptServices.GetReceiptByID(id);
                if(getReceipt == null)
                {
                    return BadRequest($"Receipt is not generated with this id :{id}");
                }
                return Ok(getReceipt);
            } catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Add Receipts
        [HttpPost]
        [Route("AddReceipt")]
        [Authorize(Roles = "dealer")]
        public async Task<ActionResult> AddReceipt(ReceiptDTO receiptDto)
        {
            try
            {
                var addReceipt = await _receiptServices.AddReceipt(receiptDto);
                if(addReceipt != "Receipt Added Successfully")
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

        #region Get Receipt By User Id

        [HttpGet]
        [Route("GetReceiptUserByID/{userId}")]
        [Authorize(Roles = "farmer,dealer")]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceiptUserByID(int userId)
        {
            try
            {
                var getReceipt = await _receiptServices.GetReceiptUserByID(userId);
                if (getReceipt == null)
                {
                    return BadRequest();
                }
                return Ok(getReceipt);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
