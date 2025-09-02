
using Microsoft.EntityFrameworkCore;

namespace SimpleBookKeepingMobile.Database.DbModels
{
	[Index(nameof(UserId),nameof(PlanId))]
	public class PlanMember : BaseEntity
	{
		public Guid UserId { get; set; }

		public Guid PlanId { get; set; }

		public Plan Plan { get; set; }
	}
}
