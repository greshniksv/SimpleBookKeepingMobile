﻿using AutoMapper;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Exceptions;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries.Handles
{
	public class GetCostsQueryHandler : IQueryHandler<GetCostsQuery, IList<CostModel>>
	{
		private readonly ICostRepository _costRepository;
		private readonly IMapper _mapper;

		public GetCostsQueryHandler(ICostRepository costRepository, IMapper mapper)
		{
			_costRepository = costRepository;
			_mapper = mapper;
		}

		public async Task<IList<CostModel>> Handle(GetCostsQuery request, CancellationToken cancellationToken)
		{
			if (request.PlanId == Guid.Empty)
			{
				throw new PlanNotFoundException(request.PlanId.ToString());
			}

			IList<Cost> costs;
			if (request.ShowDeleted)
			{
				costs = await _costRepository.GetAsync(x =>
					x.Plan.Id == request.PlanId, null, "CostDetails")
					.ToListAsync(cancellationToken);
			}
			else
			{
				costs = await _costRepository.GetAsync(x =>
					x.Plan.Id == request.PlanId && x.Deleted == false, null, "CostDetails")
					.ToListAsync(cancellationToken);
			}

			IList<CostModel> costModels = _mapper.Map<IList<CostModel>>(costs);

			return costModels;
		}
	}
}