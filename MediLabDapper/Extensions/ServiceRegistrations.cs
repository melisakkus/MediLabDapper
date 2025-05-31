using MediLabDapper.Context;
using MediLabDapper.Repositories.AboutRepositories;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.BannerRepositories;
using MediLabDapper.Repositories.ContactRepositories;
using MediLabDapper.Repositories.DepartmanRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using MediLabDapper.Repositories.GeneralAppointmentRepositories;
using MediLabDapper.Repositories.ServiceRepositories;
using MediLabDapper.Repositories.TestimonialRepositories;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddRepositoriesExt(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository,DoctorRepository>();
            services.AddScoped<IBannerRepository,BannerRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IGeneralAppointmentRepository, GeneralAppointmentRepository>();

        }

        //program.csde devamına (builder.Services.AddRepositoriesExt().AddAuthentication()... gibi) farklı metotlar ekleyebilmek için IServiceCollection dönelim ki akış bölünmesin

        //public static IServiceCollection AddRepositoriesExt(this IServiceCollection services)
        //{
        //    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        //    services.AddScoped<DapperContext>();
        //    return services;
        //}


    }
}
