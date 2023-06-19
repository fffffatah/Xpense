using AutoMapper;
using Xpense.Data.Core.Entities;
using Xpense.Api.Models;

namespace Xpense.Api.Mappers
{
    public class XpenseModelMapper : Profile
    {
        public XpenseModelMapper()
        {
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
