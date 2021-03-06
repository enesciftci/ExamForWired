using AutoMapper;
using ExamForWired.Business.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace ExamForWired.Web.Infrastructure
{
    public static class Mapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
