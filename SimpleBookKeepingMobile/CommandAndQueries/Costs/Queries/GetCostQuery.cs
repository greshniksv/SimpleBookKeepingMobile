using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries
{
	public class GetCostQuery : IQuery<CostModel>
	{
		public Guid CostId { get; set; }
	}
}