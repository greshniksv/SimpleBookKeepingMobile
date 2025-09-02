using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Credits.Queries
{
	public class GetCreditSpends : IQuery<IReadOnlyList<SpendCreditInfoModel>>
	{
		public Guid UserId { get; set; }
		public Guid CostId { get; set; }
	}
}