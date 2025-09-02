using AutoMapper;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Queries.Handlers
{
	public class GetSpendQueryHandler : IQueryHandler<GetSpendQuery, SpendModel>
	{
		private readonly ISpendRepository _repository;
		private readonly IMapper _mapper;

		public GetSpendQueryHandler(ISpendRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<SpendModel> Handle(GetSpendQuery request, CancellationToken cancellationToken)
		{
			Spend spend = await _repository.GetByIdAsync(request.SpendId);
			SpendModel spendModel = _mapper.Map<SpendModel>(spend);
			return spendModel;
		}
	}
}