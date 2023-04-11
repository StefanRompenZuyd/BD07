using BD07.Enums;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BD07.Utilities
{
    public static class NotificationHelperMethods
    {
        public static bool ContainsChannel(this ENotificationChannel channels, ENotificationChannel channelName)
        {
            return (channels & channelName) != 0;
        }
    }
}
