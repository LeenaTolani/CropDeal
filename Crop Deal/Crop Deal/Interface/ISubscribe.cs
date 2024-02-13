using Crop_Deal.Model.DTO;
using Crop_Deal.Model.Domain;

namespace Crop_Deal.Interface
{
    public interface ISubscribe
    {
        Task<bool> AddSubscribeToCrop(SubscribeDTO subscribe);
        Task<bool> UpdateSubscribeToCrop(int subscribeid, SubscribeDTO subscribe);
        Task<Subscribe> GetSubscribeToCrop(int subscribeid);
        Task<IEnumerable<Subscribe>> GetAllSubscriberToCrop();
        Task<bool> DeleteSubscribeToCrop(int subscribeid);
        Task SubscriptionNotification();
        Task<Subscribe> SubscribeByUserId(int id); 

    }
}
