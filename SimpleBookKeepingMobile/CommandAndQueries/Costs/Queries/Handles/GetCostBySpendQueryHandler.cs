using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries.Handles
{
	public class GetCostBySpendQueryHandler : IQueryHandler<GetCostBySpendQuery, Guid?>
	{
		private readonly ISpendRepository _spendRepository;

		public GetCostBySpendQueryHandler(ISpendRepository spendRepository)
		{
			_spendRepository = spendRepository;
		}

		public async Task<Guid?> Handle(GetCostBySpendQuery request, CancellationToken cancellationToken)
		{
			Spend? spend = await _spendRepository.GetAsync(x => x.Id == request.SpendId).FirstAsync(cancellationToken);
			return spend?.CostDetail.Cost.Id;
		}
	}
}