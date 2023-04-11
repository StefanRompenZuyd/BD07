using BD07.Enums;

namespace BD07.Models.Data
{
    public class Notification
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ENotificationChannel Channels { get; set; }
        public DateTimeOffset SendOn { get; set; }
        public string ForUserId { get; set; }
        public bool IsRead { get; set; }

        public User? ForUser { get; set; }

        public Notification(string id, string title, string body, ENotificationChannel channels, DateTimeOffset sendOn, string forUserId, bool isRead)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Body = body ?? throw new ArgumentNullException(nameof(body));
            Channels = channels;
            SendOn = sendOn;
            ForUserId = forUserId ?? throw new ArgumentNullException(nameof(forUserId));
            IsRead = isRead;
        }
    }
}
