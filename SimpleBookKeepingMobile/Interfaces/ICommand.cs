using MediatR;

namespace SimpleBookKeepingMobile.Interfaces
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
