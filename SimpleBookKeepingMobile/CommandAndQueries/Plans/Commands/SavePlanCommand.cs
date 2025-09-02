using System.ComponentModel.DataAnnotations;
using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Commands
{
	public class SavePlanCommand : ICommand<bool>
	{
		public PlanModel PlanModel { get; set; }

		[Required]
		public Guid UserId { get; set; }
	}
}