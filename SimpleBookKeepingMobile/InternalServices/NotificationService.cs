using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Enums;
using SimpleBookKeepingMobile.InternalServices.Interfaces;

namespace SimpleBookKeepingMobile.InternalServices
{
    public class NotificationService : INotificationService
    {
        public event Action<NotificationModel> OnNotification;

        public void ShowInfo(string message)
        {
            ShowNotification(message, NotificationType.Info);
        }

        public void ShowWarning(string message)
        {
            ShowNotification(message, NotificationType.Warning);
        }

        public void ShowError(string message)
        {
            ShowNotification(message, NotificationType.Error);
        }

        public void ShowSuccess(string message)
        {
            ShowNotification(message, NotificationType.Success);
        }

        private void ShowNotification(string message, NotificationType type)
        {
            var notification = new NotificationModel
            {
                Id = Guid.NewGuid(),
                Message = message,
                Type = type,
                Timestamp = DateTime.Now
            };

            OnNotification?.Invoke(notification);
        }
    }
}
