using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Net;
using System.Net.Mail;

namespace Crop_Deal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserServices _registerServices;
        public UserController(UserServices registerServices)
        {
            _registerServices = registerServices;
        }

        #region Add New User 
        [HttpPost]
        [Route("Adduser")]
        [AllowAnonymous]
        public async Task<ActionResult<JsonContent>> AddUser(UserDTO user)
        {
            try
            {
                var result = await _registerServices.AddUser(user);
                if (result == false)
                {
                    return BadRequest(Json("UserName already Exsists"));
                }
                return Ok(Json("success"));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update Users Details
        [HttpPut]
        [Route("Updateuser/{id}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult> UpdateUser(int id, UserDTO user)
        {
            try
            {

                if (await _registerServices.UpdateUser(id, user) == false)
                {
                    return BadRequest(null);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting All the Users Detail
        [HttpGet]
        [Route("Getalluser")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUserDetails()
        {
            try
            {
                var details = await _registerServices.GetAllUserDetails();
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

        #region Getting User by UserId 
        [HttpGet("{id}")]
        [Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<User>> GetUserDetails(int id)
        {
            try
            {
                var userDetail = await _registerServices.GetUserDetails(id);
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

        #region Deleting the user 
        [HttpDelete]
        [Route("Deleteuser")]
        //[Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult> DeleteUser(string username)
        {
            try
            {
                if (await _registerServices.DeleteUser(username) == false)
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

        #region Getting Users Details 
        [HttpGet("bankdetails/{userId}")]
        //[Authorize(Roles = "farmer,dealer,admin")]
        public async Task<ActionResult<User>> GetBankDetailsOfUser(int userId)
        {
            try
            {
                var details = await _registerServices.GetBankDetailsOfUser(userId);
                return Ok(details);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Activate and Deactivate User

        [HttpPut("ActivateStatus/{userId}")]
        [Authorize(Roles = "admin")]
        public async Task<bool> checkActivationStatus(int userId, UserDTO userDto)
        {
            try
            {
                return await _registerServices.checkActivationStatus(userId, userDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}

