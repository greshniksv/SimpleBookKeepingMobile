using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Queries
{
	public class GetSpendsQuery : IQuery<IReadOnlyList<SpendModel>>
	{
		public Guid UserId { get; set; }

		public Guid CostId { get; set; }
	}
}