using FluentValidation;
using MediatR;
using SimpleBookKeepingMobile.AbstractValidators;
using SimpleBookKeepingMobile.CommandAndQueries.Costs.Queries;
using SimpleBookKeepingMobile.CommandAndQueries.Plans.Commands;
using SimpleBookKeepingMobile.CommandAndQueries.Plans.Queries;

namespace SimpleBookKeepingMobile.CommandAndQueries.Plans.Validators
{
	public class SavePlanCommandValidator : CommandAttributesAbstractValidator<SavePlanCommand, bool>
	{
		public SavePlanCommandValidator(IMediator mediator)
		{
			RuleFor(x => x.PlanModel.Start).NotEqual(default(DateTime));

			RuleFor(x => x.PlanModel.End).NotEqual(default(DateTime));

			RuleFor(x => x.PlanModel.End)
				.GreaterThan(x => x.PlanModel.Start)
				.WithMessage("Дата окончания должна быть больше даты начала!");

			RuleFor(x=>x.PlanModel.Start).MustAsync(
				 async (model, start, c) =>
				 {
					 if (model.PlanModel.Id == Guid.Empty)
					 {
						 return true;
					 }

					 var costs = await mediator.Send(new GetCostsQuery(){ PlanId = model.PlanModel.Id });
					 var oldPlan = await mediator.Send(new GetPlanQuery { PlanId = model.PlanModel.Id });

					 if (costs.Any() && oldPlan != null &&
					     (oldPlan.Start.Date != model.PlanModel.Start.Date || oldPlan.End.Date != model.PlanModel.End.Date))
					 {
						 return false;
					 }

					 return true;
				}).WithMessage("Нельзя изменить дату, так как существуют расходы");

		}
	}
}
