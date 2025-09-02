using MediatR.Pipeline;

namespace SimpleBookKeepingMobile.Interfaces
{
	public interface INotifyValidator<TNotify> : IRequestPreProcessor<TNotify>
		where TNotify : INotify
	{
	}
}
