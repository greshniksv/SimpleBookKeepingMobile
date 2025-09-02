using MediatR;
using SimpleBookKeepingMobile.DtoModels;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Queries
{
	public class GetActivePlanCostsQuery : IRequest<IReadOnlyCollection<PlanCostsModel>>
	{
		public Guid UserId { get; set; }
	}
}