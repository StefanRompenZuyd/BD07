using BD07.Models.Data;

namespace BD07.Services.Pub
{
    public interface INotificator
    {
        public Task<bool> CanHandLe(Notification notification);
        public Task<FSentNotification> SendAsync(Notification notification);
    }
}
