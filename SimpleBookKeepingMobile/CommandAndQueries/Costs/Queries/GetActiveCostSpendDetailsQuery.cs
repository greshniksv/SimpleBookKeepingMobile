using MediatR;
using SimpleBookKeepingMobile.DtoModels;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries
{
	public class GetActiveCostSpendDetailsQuery : IRequest<IList<CostSpendDetailModel>>
	{
		public Guid UserId { get; set; }

		public Guid CostId { get; set; }
	}
}