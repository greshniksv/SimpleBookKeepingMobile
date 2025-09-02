using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Commands
{
	public class DeleteSpendCommand : ICommand<bool>
	{
		public Guid SpendId { get; set; }
	}
}
