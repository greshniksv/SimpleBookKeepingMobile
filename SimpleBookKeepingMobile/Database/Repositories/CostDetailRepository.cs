using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Interfaces;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;

namespace SimpleBookKeepingMobile.Database.Repositories
{
	public class CostDetailRepository : BaseRepository<CostDetail>, ICostDetailRepository
	{
		public CostDetailRepository(IMainContext context)
			: base(context)
		{
		}
	}
}
