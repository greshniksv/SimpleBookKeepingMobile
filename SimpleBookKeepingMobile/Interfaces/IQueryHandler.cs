using MediatR;

namespace SimpleBookKeepingMobile.Interfaces
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IRequest<TResponse>
    {
    }
}
