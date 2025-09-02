using AutoMapper;
using SimpleBookKeepingMobile.Database.DbModels;
using SimpleBookKeepingMobile.DtoModels;

namespace SimpleBookKeepingMobile.AutoMapperProfiles
{
	public class DbToViewModelProfile : Profile
	{
		public DbToViewModelProfile()
		{
			CreateMap<SpendModel, Spend>();

			CreateMap<Spend, SpendModel>()
				.ForMember(dst => dst.UserId, opt => opt.MapFrom(src => src.UserId));

			CreateMap<Plan, PlanCostsModel>()
				.ForMember(dst => dst.UserMembers, opt => opt.MapFrom(src => src.PlanMembers.Select(x => x.UserId)))
				.ForMember(dst => dst.Costs, opt => opt.MapFrom(src => src.Costs.Where(x => x.Deleted == false)));

			CreateMap<Plan, PlanModel>()
				.ForMember(dst => dst.UserMembers, opt => opt.MapFrom(src => src.PlanMembers.Select(x => x.UserId)));

			CreateMap<PlanModel, Plan>()
				.ForMember(dst => dst.PlanMembers, opt => opt.Ignore());

			CreateMap<PlanMember, PlanMemberModel>();
			CreateMap<PlanMemberModel, PlanMember>();

			CreateMap<Cost, CostModel>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dst => dst.PlanId, opt => opt.MapFrom(src => src.Plan.Id))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));

			CreateMap<CostModel, Cost>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dst => dst.CostDetails, opt => opt.Ignore());

			CreateMap<CostDetail, CostDetailModel>();
			CreateMap<CostDetailModel, CostDetail>();

			CreateMap<Cost, SimpleCostModel>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dst => dst.PlanId, opt => opt.MapFrom(src => src.Plan.Id))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));

			CreateMap<SimpleCostModel, Cost>()
				.ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dst => dst.CostDetails, opt => opt.Ignore());
		}
	}
}
