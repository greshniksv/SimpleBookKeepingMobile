using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Commands.Handlers
{
	public class DeleteSpendCommandHandler : ICommandHandler<DeleteSpendCommand, bool>
	{
		private readonly ISpendRepository _spendRepository;

		public DeleteSpendCommandHandler(ISpendRepository spendRepository)
		{
			_spendRepository = spendRepository;
		}

		public async Task<bool> Handle(DeleteSpendCommand request, CancellationToken cancellationToken)
		{
			await _spendRepository.DeleteAsync(request.SpendId, true);
			return true;
		}
	}
}
