using AutoMapper;
using Xpense.Extension.Core.Entities;
using Xpense.Models;

namespace Xpense.Mappers
{
    public class XpenseModelMapper : Profile
    {
        public XpenseModelMapper()
        {
            CreateMap<Expense, ExpenseViewModel>()
                .ForMember(dest => dest.Category, src => src.MapFrom(x => x.ExpenseCategory.Name));
            CreateMap<ExpenseAddModel, Expense>();

            CreateMap<ExpenseCategory, ExpenseCategoryViewModel>();
            CreateMap<ExpenseCategoryAddModel, ExpenseCategory>();
            CreateMap<ExpenseCategoryEditModel, ExpenseCategory>().ReverseMap();
        }

        public static class CustomMapper
        {
            private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<XpenseModelMapper>();
                });
                return config.CreateMapper();
            });

            public static IMapper Mapper => Lazy.Value;
        }
    }
}
