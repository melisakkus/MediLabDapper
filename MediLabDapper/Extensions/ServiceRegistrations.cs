﻿using MediLabDapper.Context;
using MediLabDapper.Repositories.DepartmanRepositories;
using MediLabDapper.Repositories.DoctorRepositories;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddRepositoriesExt(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository,DoctorRepository>();
            services.AddScoped<DapperContext>();

        }

        //public static IServiceCollection AddRepositoriesExt(this IServiceCollection services)
        //{
        //    services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        //    services.AddScoped<DapperContext>();
        //    return services;
        //}
        //program.csde devamına (builder.Services.AddRepositoriesExt()...) farklı extension metotları ekleyebiliriz


    }
}
