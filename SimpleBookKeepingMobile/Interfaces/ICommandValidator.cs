using MediatR.Pipeline;

namespace SimpleBookKeepingMobile.Interfaces
{
    public interface ICommandValidator<TModel, TResponce> : IRequestPreProcessor<TModel>
    where TModel : ICommand<TResponce>
    {
    }
}
