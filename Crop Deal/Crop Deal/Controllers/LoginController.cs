using Crop_Deal.Model.DTO;
using Crop_Deal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crop_Deal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        #region Get Valid login Credentials For User
        [HttpPost]
        public async Task<ActionResult<JsonContent>> Login(LoginDTO logindto )
        {
            try
            {

                var tokenString = await _loginService.Login(logindto);
                if(tokenString != null )
                {
                    return Ok(Json(tokenString));
                }
                else
                {
                    return Unauthorized("The login details are incorrect");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
