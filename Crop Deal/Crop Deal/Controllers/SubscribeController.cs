using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Repository;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscribeController : Controller
    {
        private readonly SubscribeServices _subscribeServices;
        public SubscribeController(SubscribeServices subscribeServices)
        {
            _subscribeServices = subscribeServices;
        }

        #region Add Subscribe
        [HttpPost]
        [Route("AddSubscribe")]
        [Authorize(Roles = "dealer")]
        public async Task<ActionResult> AddSubscribeToCrop([FromBody]SubscribeDTO subscribe)
        {
            try
            {
                if (await _subscribeServices.AddSubscribeToCrop(subscribe) == false)
                {
                    return BadRequest();
                }

                return Ok();
            } catch (Exception ex) {
                throw;
            }
        }
        #endregion

        #region Delete the Subscription 
        [HttpDelete]
        [Route("DeleteSubscribe/{subscribeid}")]
        [Authorize(Roles = "dealer")]
        public async Task<ActionResult> DeleteSubscribeToCrop(int subscribeid)
        {
            try
            {
                if (await _subscribeServices.DeleteSubscribeToCrop(subscribeid) == false)
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

        #region Get All Subscribed crops By User Id

        [HttpGet]
        [Route("SubscribedCropByUserId/{id}")]
        [Authorize(Roles = "dealer")]
        public async Task<ActionResult<Subscribe>> SubscribeByUserId(int id)
        {
            var result = await _subscribeServices.SubscribeByUserId(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        #endregion

        #region Get All the Subscribed Crop
        [HttpGet]
        [Route("GetSubscribe")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<IEnumerable<Subscribe>>> GetAllSubscriberToCrop()
        {
            try
            {
                var details = await _subscribeServices.GetAllSubscriberToCrop();
                if (details == null)
                {
                    return BadRequest("Subscriber is empty");
                }

                return Ok(details);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All crops By Subscribed Id
        [HttpGet]
        [Route("GetSubscribe/{subscribeid}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<Subscribe>> GetSubscribeToCrop(int subscribeid)
        {
            try
            {
                var details = await _subscribeServices.GetSubscribeToCrop(subscribeid);
                if (details == null)
                {
                    return BadRequest("Subscriber is empty");
                }

                return Ok(details);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update The Subscribe Details 
        [HttpPut]
        [Route("UpdateSubscribe")]
        [Authorize(Roles = "dealer,admin")]
        public async Task<ActionResult> UpdateSubscribeToCrop(int subscribeid, SubscribeDTO subscribe)
        {
            try
            {
                if (await _subscribeServices.UpdateSubscribeToCrop(subscribeid, subscribe) == false)
                {
                    return BadRequest("Bank Details Already Exists");
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
