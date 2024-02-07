using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Crop_Deal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crop_Deal.Repository
{
    public class LoginRepo : ILogin
    {
        private readonly CropDetailDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginRepo(CropDetailDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        #region Checking Valid Credentials For User
        public async Task<String> Login(LoginDTO logindto)
        {
            try
            {
                var getDetails = await  _context.Users.FirstOrDefaultAsync(u => ( u.UserName == logindto.User || u.Email == logindto.User) && u.Password == logindto.Password && u.ActiveStatus == true);
                if (getDetails != null)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Audience = "YourAudience",
                        Issuer = "YourIssuer",
                        Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, getDetails.UserName), new Claim(ClaimTypes.Role, getDetails.Role), new Claim(ClaimTypes.NameIdentifier , getDetails.UserId.ToString())}),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);
                    return tokenString ;
                }
                return "Invalid User Details";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

    }
}
