using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Commands
{
	public class RemoveCostCommand : ICommand<bool>
	{
		public Guid CostId { get; set; }
	}
}