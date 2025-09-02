using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Commands
{
	public class UpdateSpendCommand : ICommand<bool>
	{
		public AddSpendModel SpendModel { get; set; }

		public Guid UserId { get; set; }
	}
}