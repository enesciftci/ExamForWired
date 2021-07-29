using ExamForWired.Business.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ExamForWired.Web.Infrastructure
{
    public static class AppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExamService, ExamService>()
              .AddScoped(x => new Lazy<IExamService>(() => x.GetRequiredService<IExamService>()));
            services.AddScoped<IArticleService, ArticleService>()
              .AddScoped(x => new Lazy<IArticleService>(() => x.GetRequiredService<IArticleService>()));
            return services;
        }
    }
}
