using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Deal.Services
{
    public class UserServices
    {
        private readonly IUser _iuser;
        public UserServices(IUser iuser)
        {
            _iuser = iuser;
        }

        #region Add New User 
        public async Task<bool> AddUser(UserDTO user)
        {
            try
            {
                return await _iuser.AddUser(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update Users Details
        public async Task<bool> UpdateUser(int id, UserDTO user)
        {
            try
            {
                return await _iuser.UpdateUser(id, user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region deleting the user id 

        public async Task<bool> DeleteUser(string username)
        {
            try
            {
                return await _iuser.DeleteUser(username);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting All the Users Detail
        public async Task<IEnumerable<User>> GetAllUserDetails()
        {
            try
            {
                return await _iuser.GetAllUserDetails();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting User by UserName 
        public async Task<User> GetUserDetails(int id)
        {
            try
            {
                return await _iuser.GetUserDetails(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Getting User by UserName 

        public async Task<User> GetBankDetailsOfUser(int userId)
        {
            try
            {
                return await _iuser.GetBankDetailsOfUser(userId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Activate and Deactivate User
        public async Task<bool> checkActivationStatus(int userId, UserDTO userDto)
        {
            try
            {
                return await _iuser.checkActivationStatus(userId,userDto);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
