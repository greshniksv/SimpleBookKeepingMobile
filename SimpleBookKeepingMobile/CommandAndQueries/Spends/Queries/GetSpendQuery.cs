using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Queries
{
	public class GetSpendQuery : IQuery<SpendModel>
	{
		public Guid SpendId { get; set; }
	}
}