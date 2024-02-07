using Crop_Deal.Interface;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Services
{
    public class SubscribeServices 
    {
        private readonly ISubscribe _isubscribe;
        public SubscribeServices(ISubscribe isubscribe)
        {
            _isubscribe = isubscribe;
        }

        #region Subscribin to the Crop
        public async Task<bool> AddSubscribeToCrop(SubscribeDTO subscribe)
        {
            try
            {
                return await _isubscribe.AddSubscribeToCrop(subscribe);
            }catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region removing the Subscription

        public async Task<bool> DeleteSubscribeToCrop(int subscribeid)
        {
            try
            {
                return await _isubscribe.DeleteSubscribeToCrop(subscribeid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Get All the Subscribed Crop
        public async Task<IEnumerable<Subscribe>> GetAllSubscriberToCrop()
        {
            try
            {
                return await _isubscribe.GetAllSubscriberToCrop();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All crops By Subscribed Id

        public async Task<Subscribe> GetSubscribeToCrop(int subscribeid)
        {
            try
            {
                return await _isubscribe.GetSubscribeToCrop(subscribeid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Update The Subscribe Details for the Crop

        public async Task<bool> UpdateSubscribeToCrop(int subscribeid, SubscribeDTO subscribe)
        {
            try
            {
                return await _isubscribe.UpdateSubscribeToCrop(subscribeid, subscribe);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Get All Subscribed crops By User Id
        public async Task<Subscribe> GetSubscribeToCropByUserId(int userid)
        {
            try
            {
                return await _isubscribe.GetSubscribeToCropByUserId(userid);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
