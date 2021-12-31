using AutoMapper;
using API.Dtos;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles(){
            CreateMap<Product, ProductDto>()
            .ForMember(x=> x.ProductBrand, y=> y.MapFrom(f=> f.ProductBrand.Name))
            .ForMember(x=> x.ProductType, y=> y.MapFrom(f=> f.ProductType.Name))
            .ForMember(x=>x.PictureUrl, y => y.MapFrom<ProductUrlResolver>());
        }
    }
}