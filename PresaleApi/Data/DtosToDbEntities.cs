using AutoMapper;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Models.Request;

namespace PresaleApi.Data
{
    public class DtosToDbEntities : Profile
    {
        public DtosToDbEntities()
        {
            CreateMap<FeatureRequest, Feature>();
            CreateMap<ConstructionTypeRequest, ConstructionType>();
            CreateMap<PropertyTypeRequest, PropertyType>();
            CreateMap<NearByRequest, NearBy>();
            CreateMap<ProductRequest, Product>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<TestimonialRequest, Testimonial>();
        }
    }
}
