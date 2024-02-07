using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Deal.Interface
{
    public interface IUser
    {
        Task<bool> AddUser(UserDTO user);
        Task<bool> UpdateUser(int id,UserDTO user);
        Task<IEnumerable<User>> GetAllUserDetails();
        Task<User> GetUserDetails(int userId);
        Task<bool> DeleteUser(string username);
        Task<bool> CheckIfUserExists(UserDTO user);
        Task<User> GetBankDetailsOfUser(int userId);
        Task<bool> SendMail(UserDTO user);
        Task<bool> checkActivationStatus(int userId, UserDTO userDto);
    }
}
