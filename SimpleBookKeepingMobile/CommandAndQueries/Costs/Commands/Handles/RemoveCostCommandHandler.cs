using AutoMapper;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.Exceptions;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Commands.Handles
{
	public class RemoveCostCommandHandler : ICommandHandler<RemoveCostCommand, bool>
	{
		private readonly IMapper _mapper;
		private readonly ICostRepository _costRepository;

		public RemoveCostCommandHandler(IMapper mapper, ICostRepository costRepository)
		{
			_mapper = mapper;
			_costRepository = costRepository;
		}

		public async Task<bool> Handle(RemoveCostCommand request, CancellationToken cancellationToken)
		{
			Cost cost;
			cost = await _costRepository.GetAsync(x => x.Id == request.CostId).FirstAsync(cancellationToken);
			if (cost == null)
			{
				throw new CostNotFoundException(request.CostId.ToString());
			}
			//cost.CostDetails.Clear();

			//cost.Plan = null;
			cost.Deleted = true;
			_costRepository.Update(cost);
			await _costRepository.SaveChangesAsync(true, cancellationToken);

			return true;
		}
	}
}