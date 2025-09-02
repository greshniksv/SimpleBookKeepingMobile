﻿using AutoMapper;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Spends.Queries.Handlers
{
	public class GetSpendsQueryHandler : IQueryHandler<GetSpendsQuery, IReadOnlyList<SpendModel>>
	{
		private readonly ISpendRepository _repository;
		private readonly IMapper _mapper;

		public GetSpendsQueryHandler(ISpendRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		/// <summary>Handles a request</summary>
		/// <param name="request">The request request</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Response from the request</returns>
		public async Task<IReadOnlyList<SpendModel>> Handle(GetSpendsQuery request, CancellationToken cancellationToken)
		{
			if (request.CostId == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(request));
			}

			List<Spend> items =
				await _repository.GetAsync(x =>
						x.UserId == request.UserId &&
						x.CostDetail.Cost.Id == request.CostId)
					.ToListAsync(cancellationToken);

			IList<SpendModel> models = _mapper.Map<IList<SpendModel>>(items);

			return models.AsReadOnly();
		}
	}
}