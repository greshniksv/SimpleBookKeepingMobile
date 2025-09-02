using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Interfaces;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;

namespace SimpleBookKeepingMobile.Database.Repositories
{
	public class PlanRepository : BaseRepository<Plan>, IPlanRepository
	{
		public PlanRepository(IMainContext context)
			: base(context)
		{
		}
	}
}
