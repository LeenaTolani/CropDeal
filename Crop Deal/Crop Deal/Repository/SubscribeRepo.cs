using Crop_Deal.Interface;
using Crop_Deal.Model;
using Crop_Deal.Model.Domain;
using Crop_Deal.Model.DTO;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;

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
                    //CropTypeId = subscribe.CropTypeId
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
        public async Task<Subscribe> SubscribeByUserId(int id)
        {
            try
            {
                return await _context.Subscribes.Where(a => a.UserId == id).FirstOrDefaultAsync();
            } catch(Exception ex)
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
                   // updateSubscriber.CropTypeId = subscribe.CropTypeId;
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


        #region Subscription Notification
        public async Task SubscriptionNotification()
        {
            try
            {
                var subscriptionList = await _context.Subscribes.Where(x => x.Subscriber == true).ToListAsync();
                foreach (var item in subscriptionList)
                {
                    var dealer = await _context.Users.FirstOrDefaultAsync(x => x.UserId == item.UserId);
                    if (dealer == null)
                        return ;

                    await SendEmail(dealer);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Send Mail To Subscriber
        public async Task SendEmail(User user)
        {
            try
            {

                var dealerDetails = await _context.Users.FirstOrDefaultAsync(a => a.UserId == user.UserId);

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("leena.tolani11@gmail.com"));
                email.To.Add(MailboxAddress.Parse(dealerDetails.Email));
                email.Subject = "New crops Available!";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Dear " + dealerDetails.Name + ",<br>" +
                    "<p> New Crops are Available Please Login Now to Explore the New Crops</p>" 

                };
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("leena.tolani11@gmail.com", "rkfk xedb ttey mgae");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

    }
}
