using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Commands
{
	public class GenerateCostCommand : ICommand<CostModel>
	{
		public Guid PlanId { get; set; }
	}
}