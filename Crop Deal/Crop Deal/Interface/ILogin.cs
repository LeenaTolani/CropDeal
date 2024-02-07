using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;

namespace Crop_Deal.Interface
{
    public interface ILogin
    {
        Task<String> Login(LoginDTO logindto );
    }
}
