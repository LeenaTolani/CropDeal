using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Services
{
    public class LoginService
    {
        private readonly ILogin _iLogin;
        public LoginService(ILogin iLogin)
        {
            _iLogin = iLogin;
        }

        #region Checking Valid Credentials For User
        public async Task<String> Login(LoginDTO logindto)
        {
            try
            {
                return await _iLogin.Login(logindto);
            }catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

    }
}
