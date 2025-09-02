using SimpleBookKeepingMobile.Enums;

namespace SimpleBookKeepingMobile.DtoModels
{
    public class NotificationModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
