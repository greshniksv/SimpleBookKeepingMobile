using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Interfaces;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;

namespace SimpleBookKeepingMobile.Database.Repositories
{
	public class SpendRepository : BaseRepository<Spend>, ISpendRepository
	{
		public SpendRepository(IMainContext context)
			: base(context)
		{
		}
	}
}
