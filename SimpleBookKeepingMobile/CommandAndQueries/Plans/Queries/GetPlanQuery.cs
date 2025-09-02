using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Queries
{
	public class GetPlanQuery : IQuery<PlanModel>
	{
		public Guid PlanId { get; set; }
	}
}