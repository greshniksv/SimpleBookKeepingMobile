using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Commands
{
	public class SaveCostCommand : ICommand<bool>
	{
		public CostModel Cost { get; set; }
	}
}