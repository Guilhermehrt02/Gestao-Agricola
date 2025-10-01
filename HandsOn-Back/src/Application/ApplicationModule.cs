using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;
using Application.Module.IA;

namespace Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();
            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddSingleton(configuration!);
            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IExpenseServices, ExpenseServices>();
            services.AddScoped<IRevenueServices, RevenueServices>();
            services.AddScoped<IReportServices, ReportServices>();
            services.AddScoped<IUploadServices, UploadServices>();
            services.AddScoped<IFarmServices, FarmServices>();
            services.AddScoped<IHarvestServices, HarvestServices>();
            services.AddScoped<IPlotServices, PlotServices>();
            services.AddScoped<IDiagnosisServices, DiagnosisServices>();
            services.AddScoped<IUserFarmServices, UserFarmServices>();
            services.AddHttpClient<IAIServiceClient, AIServiceClient>(client =>
            {
                var baseUrl = configuration!.GetSection("AIService:BaseUrl").Value;
                if (string.IsNullOrEmpty(baseUrl))
                    throw new InvalidOperationException("AIService:BaseUrl não configurado no appsettings.json");

                client.BaseAddress = new Uri(baseUrl);
                client.Timeout = TimeSpan.FromMinutes(10);
            });
            services.AddScoped<IDiseaseService, DiseaseService>();

            services.AddScoped<IClassifier, Classifier>();
            services.AddScoped<IAIProvider, GPT>();

            return services;
        }
    }
}