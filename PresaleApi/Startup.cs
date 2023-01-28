using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PresaleApi.Repository;
using PresaleApi.Validation;
using PresaleApi.Validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PresaleApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddDbContext<PresaleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            #region Repository registrations
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IConstructionTypeRepository, ConstructionTypeRepository>();
            services.AddTransient<IPropertyTypeRepository, PropertyTypeRepository>();
            services.AddTransient<INearByRepository, NearByRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IStudentsRepository, StudentsRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ITeachersRepository, TeachersRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IWorkersRepository, WorkersRepository>();
            services.AddTransient<IStatesRepository, StatesRepository>();
            services.AddTransient<IProductInquiryRepository, ProductInquiryRepository>();
            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<IImageDumpRepository, ImageDumpRepository>();
            services.AddTransient<ICmsRepository, CmsRepository>();
            services.AddTransient<ICommonRepository, CommonRepository>();
            #endregion
            #region Validator Registraytions
            services.AddValidatorsFromAssemblyContaining<FeatureValidator>();
            services.AddValidatorsFromAssemblyContaining<ConstructionTypeValidator>();
            services.AddValidatorsFromAssemblyContaining<PropertyTypeValidator>();
            services.AddValidatorsFromAssemblyContaining<NearByValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
            services.AddValidatorsFromAssemblyContaining<DepartmentValidator>();
            services.AddValidatorsFromAssemblyContaining<EmployeeValidator>();
            services.AddValidatorsFromAssemblyContaining<StudentsValidator>();
            services.AddValidatorsFromAssemblyContaining<StateValidator>();
            services.AddValidatorsFromAssemblyContaining<TeachersValidator>();
            services.AddValidatorsFromAssemblyContaining<SubjectValidator>();
            services.AddValidatorsFromAssemblyContaining<WorkersValidator>();
            services.AddValidatorsFromAssemblyContaining<StatesValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductInquiryValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductInquiryValidator>();
            services.AddValidatorsFromAssemblyContaining<ContactUsValidator>();
            services.AddValidatorsFromAssemblyContaining<ImageDumpValidator>();
            services.AddValidatorsFromAssemblyContaining<CmsValidator>();
            #endregion


            //services.AddControllers();
            services.AddControllers()
                .AddFluentValidation(options =>
                {
                    // Validate child properties and root collection elements
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;

                    // Automatic registration of validators in assembly
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            // Named Policy
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: "AllowOrigin",
                    builder => {
                        builder.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization(); 
            app.UseCors("AllowOrigin");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"public")),
                RequestPath = new PathString("/public")
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
