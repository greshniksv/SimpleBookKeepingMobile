using SimpleBookKeepingMobile.DtoModels;

namespace SimpleBookKeepingMobile.InternalServices.Interfaces
{
    public interface INotificationService
    {
        void ShowInfo(string message);
        void ShowWarning(string message);
        void ShowError(string message);
        void ShowSuccess(string message);
    }
}
