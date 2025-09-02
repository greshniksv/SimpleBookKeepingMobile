using MediatR;

namespace SimpleBookKeepingMobile.Interfaces
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
