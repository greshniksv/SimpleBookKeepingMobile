using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Interfaces;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;

namespace SimpleBookKeepingMobile.Database.Repositories
{
	public class PlanMemberRepository : BaseRepository<PlanMember>, IPlanMemberRepository
	{
		public PlanMemberRepository(IMainContext context)
			: base(context)
		{
		}
	}
}
