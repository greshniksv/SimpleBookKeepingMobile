using Microsoft.EntityFrameworkCore.Storage;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Interfaces;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Commands.Handlers
{
	public class UpdateSpendCommandHandler : ICommandHandler<UpdateSpendCommand, bool>
	{
		private readonly IMainContext _mainContext;
		private readonly ICostDetailRepository _costDetailRepository;
		private readonly ISpendRepository _spendRepository;

		public UpdateSpendCommandHandler(
            IMainContext mainContext,
            ICostDetailRepository costDetailRepository,
			ISpendRepository spendRepository)
		{
			_mainContext = mainContext;
			_costDetailRepository = costDetailRepository;
			_spendRepository = spendRepository;
		}

		/// <summary>Handles a void request</summary>
		/// <param name="request">The request request</param>
		/// <param name="cancellationToken"></param>
		public async Task<bool> Handle(UpdateSpendCommand request, CancellationToken cancellationToken)
		{
			await using IDbContextTransaction transaction = await _mainContext.BeginTransactionAsync(cancellationToken);

			try
			{
				var spendModel = request.SpendModel;
				Spend oldSpend = await _spendRepository.GetByIdAsync(spendModel.Id.Value);
				oldSpend.UserId = Guid.Empty;
				oldSpend.Comment = spendModel.Comment;
				oldSpend.CostDetail = await _costDetailRepository.GetByIdAsync(spendModel.CostDetailId);
				oldSpend.Value = spendModel.Value;

				_spendRepository.Update(oldSpend);
				await _spendRepository.SaveChangesAsync(true, cancellationToken);
				await transaction.CommitAsync(cancellationToken);
			}
			catch (Exception e)
			{
				await transaction.RollbackAsync(cancellationToken);
				throw;
			}

			return true;
		}
	}
}