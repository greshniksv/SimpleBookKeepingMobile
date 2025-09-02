using System.ComponentModel;
using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries
{
	public class GetCostsQuery : IQuery<IList<CostModel>>
	{
		public Guid PlanId { get; set; }

		[DefaultValue(false)]
		public bool ShowDeleted { get; set; }
	}
}