using BD07.Enums;
using BD07.Models.Data;

namespace BD07.Services.pub
{
    public interface INotificationManager
    {
        public Task<Notification> SendNotificationAsync(string userId, string title, string body, ENotificationPriority priority);
        public Task<Notification> SendNotificationAsync(string userId, string title, string body, ENotificationPriority priority, ENotificationChannel notificationChannels);
    }
}
