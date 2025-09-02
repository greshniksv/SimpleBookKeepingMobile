﻿using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.Database.Repositories.Interfaces;
using SimpleBookKeepingMobile.Interfaces;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Commands.Handlers
{
	public class RemovePlanCommandHandler : ICommandHandler<RemovePlanCommand, bool>
	{
		private readonly IPlanRepository _planRepository;

		public RemovePlanCommandHandler(IPlanRepository planRepository)
		{
			_planRepository = planRepository;
		}

		public async Task<bool> Handle(RemovePlanCommand request, CancellationToken cancellationToken)
		{
			Plan plan = await _planRepository.GetByIdAsync(request.PlanId);
			if (plan == null)
			{
				return false;
			}

			plan.Deleted = true;
			_planRepository.Update(plan);
			await _planRepository.SaveChangesAsync(true, cancellationToken);
			return true;
		}
	}
}