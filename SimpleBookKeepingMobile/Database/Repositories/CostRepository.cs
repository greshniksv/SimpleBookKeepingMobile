using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Interfaces;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;

namespace SimpleBookKeepingMobile.Database.Repositories
{
	public class CostRepository : BaseRepository<Cost>, ICostRepository
	{
		public CostRepository(IMainContext context)
			: base(context)
		{
		}
	}
}
