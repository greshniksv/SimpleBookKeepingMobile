using MediatR;

namespace SimpleBookKeepingMobile.Interfaces
{
	public interface INotifyHandler<TNotify> : IRequestHandler<TNotify, bool>
		where TNotify : INotify
	{
	}
}
