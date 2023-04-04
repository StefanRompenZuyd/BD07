using BD07.Enums;
using BD07.Models.Data;
using BD07.Services.pub;
using BD07.Services.Pub;
using System.Reflection.Metadata.Ecma335;

namespace BD07.Services
{
    public class NotificationManager : INotificationManager
    {
        private readonly static ENotificationChannel _allNotificationChannels = ENotificationChannel.Push | ENotificationChannel.Email | ENotificationChannel.Sms;

        private readonly IEnumerable<INotificator> _notificators;

        public NotificationManager(IEnumerable<INotificator> notificators)
        {
            _notificators = notificators;
        }

        public Task MarkNotificationAsReadAsync(string notificationId)
        {
            //TODO: remove notificationId in database
            return Task.CompletedTask;
        }

        public Task<Notification> SendNotificationAsync(string userId, string title, string body, ENotificationPriority priority)
        {
            return SendNotificationAsync(userId, title, body, priority, _allNotificationChannels);
        }

        public async Task<Notification> SendNotificationAsync(string userId, string title, string body, ENotificationPriority priority, ENotificationChannel notificationChannels)
        {
            List<Task<FSentNotification>> sendTasks = new List<Task<FSentNotification>>();
            var notification = new Notification("-1", title, body, _allNotificationChannels, DateTimeOffset.UtcNow, userId);

            foreach (var notificator in _notificators)
            {
                sendTasks.Add(notificator.SendAsync(notification));
            }

            await Task.WhenAll(sendTasks.ToArray());

            return notification;
        }
    }
}
