using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Credits.Commands
{
	public class SaveCreditSpendCommand : ICommand<bool>
	{
		public IReadOnlyCollection<AddCreditSpendModel> SpendModels { get; set; }

		public Guid UserId { get; set; }
	}
}