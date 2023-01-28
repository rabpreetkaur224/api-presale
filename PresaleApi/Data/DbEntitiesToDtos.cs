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
            CreateMap<Department, DepartmantResponse>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<Students, StudentsResponse>();
            CreateMap<State, StateResponse>();
            CreateMap<TeacherView, TeachersResponse>();
            CreateMap<Subject, SubjectResponse>();
            CreateMap<WorkersView, WorkersResponse>();
            CreateMap<States, StatesResponse>();
            CreateMap<ProductInquiry, ProductInquiryResponse>();
            CreateMap<ContactUs, ContactUsResponse>();
            CreateMap<ImageDump, ImageDumpResponse>();
            CreateMap<Cms, CmsResponse>();


        }
    }

    
}
