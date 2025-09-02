using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Queries
{
	public class GetPlanStatusQuery : IQuery<PlanStatusModel>
	{
		public Guid PlanId { get; set; }
	}
}