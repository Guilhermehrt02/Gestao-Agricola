using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Services;

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
            // services.AddScoped<IDiagnosisServices, DiagnosisServices>();
            // services.AddScoped<IPlotServices, PlotServices>();
            
            return services;
        }
    }
}