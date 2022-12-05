using AutoMapper;
using PresaleApi.DataBaseEntity;
using PresaleApi.Models;
using PresaleApi.Models.Response;

namespace PresaleApi.Data
{
    public class DbEntitiesToDtos : Profile
    {
        public DbEntitiesToDtos()
        {
            CreateMap<Feature, FeatureResponse>();
            CreateMap<ConstructionType, ConstructionTypeResponse>();
            CreateMap<PropertyType, PropertyTypeResponse>();
            CreateMap<NearBy, NearByResponse>();
            CreateMap<Product , ProductResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<Testimonial, TestimonialResponse>();


        }
    }

    
}
