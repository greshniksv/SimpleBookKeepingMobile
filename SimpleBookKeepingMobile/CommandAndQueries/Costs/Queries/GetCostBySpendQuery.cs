using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries
{
	public class GetCostBySpendQuery : IQuery<Guid?>
	{
		public Guid SpendId { get; set; }
	}
}