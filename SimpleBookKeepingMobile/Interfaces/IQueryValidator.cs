using MediatR.Pipeline;

namespace SimpleBookKeepingMobile.Interfaces
{
	public interface IQueryValidator<TModel, TResponse> : IRequestPreProcessor<TModel>
	where TModel : IQuery<TResponse>
	{
	}
}
