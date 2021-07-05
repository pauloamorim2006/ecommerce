using System.Collections.Generic;

namespace ECommerce.Core.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}