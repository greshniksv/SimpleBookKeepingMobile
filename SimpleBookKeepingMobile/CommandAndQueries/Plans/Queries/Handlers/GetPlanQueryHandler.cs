using AutoMapper;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.DtoModels;
using SimpleBookKeepingMobile.Exceptions;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Queries.Handlers
{
	public class GetPlanQueryHandler : IQueryHandler<GetPlanQuery, PlanModel>
	{
		private readonly IPlanRepository _planRepository;
		private readonly IMapper _mapper;

		public GetPlanQueryHandler(IPlanRepository planRepository, IMapper mapper)
		{
			_planRepository = planRepository;
			_mapper = mapper;
		}

		public async Task<PlanModel> Handle(GetPlanQuery request, CancellationToken cancellationToken)
		{
			List<Plan> plans = await _planRepository
				.GetAsync(p => p.Id == request.PlanId && p.Deleted == false,null, "PlanMembers").ToListAsync(cancellationToken);

			if (!plans.Any())
			{
				throw new PlanNotFoundException($"Plan id: {request.PlanId.ToString()}");
			}

			return _mapper.Map<PlanModel>(plans.First());
		}
	}
}