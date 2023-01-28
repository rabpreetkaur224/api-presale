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
            CreateMap<DepartmentRequest, Department>();
            CreateMap<StudentsRequest, Students>();
            CreateMap<StateRequest, State>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<TeachersRequest, Teachers>();
            CreateMap<SubjectRequest, Subject>();
            CreateMap<WorkersRequest, Workers>();
            CreateMap<StatesRequest, States>();
            CreateMap<ProductInquiryRequest, ProductInquiry>();
            CreateMap<ContactUsRequest, ContactUs>();
            CreateMap<ImageDumpRequest, ImageDump>();
            CreateMap<CmsRequest, Cms>();
        }
    }
}
