using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Commands
{
	public class RemovePlanCommand : ICommand<bool>
	{
		public Guid PlanId { get; set; }
	}
}