using AutoMapper;
using Onion.Library.Application.Feat_Product.ViewModels;
using Onion.Library.Domain.Feat_Product.Entities;

namespace Onion.Library.Application.Mapper
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<Product, ProductPutResponseViewModel>().ReverseMap();
            CreateMap<Product, ProductPostRequestViewModel>().ReverseMap();
            CreateMap<Product, ProductGetRequestViewModel>().ReverseMap();
        }
    }
}
