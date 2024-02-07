using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Crop_Deal.Repository
{
    public class SubscribeRepo : ISubscribe
    {
        private readonly CropDetailDbContext _context;
        public SubscribeRepo(CropDetailDbContext context)
        {
            _context = context;
        }

        #region Subscribing to the Crop
        public async Task<bool> AddSubscribeToCrop(SubscribeDTO subscribe)
        {
            try
            {
                if (subscribe == null)
                {
                    return false;
                }
                var addSubscriber = new Subscribe
                {
                    Subscriber = subscribe.Subscriber,
                    UserId = subscribe.UserId,
                    CropTypeId = subscribe.CropTypeId
                };
                await _context.Subscribes.AddAsync(addSubscriber);
                await _context.SaveChangesAsync();
                return true;

            } catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region Delete Subscription
        public async Task<bool> DeleteSubscribeToCrop(int subscribeid)
        {
            try
            {
                var subscribeDetails = await _context.Subscribes.FirstOrDefaultAsync(u => (u.SubscribeId == subscribeid));
                if (subscribeDetails != null)
                {
                    _context.Subscribes.Remove(subscribeDetails);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;

            } catch (Exception ex)
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
                return await _context.Subscribes.ToListAsync();
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
                var subscribeDetails = await _context.Subscribes.FirstOrDefaultAsync(u => u.SubscribeId == subscribeid);
                return subscribeDetails;
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
                return await _context.Subscribes.FirstOrDefaultAsync(u => u.UserId == userid);
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
                if (subscribe == null)
                {
                    return false;
                }

                var updateSubscriber= await _context.Subscribes.FirstOrDefaultAsync(u => u.SubscribeId == subscribeid);
                if (updateSubscriber != null)
                {
                    updateSubscriber.Subscriber = subscribe.Subscriber;
                    updateSubscriber.UserId = subscribe.UserId;
                    updateSubscriber.CropTypeId = subscribe.CropTypeId;
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
