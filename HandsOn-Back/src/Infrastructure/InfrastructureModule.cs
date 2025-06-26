using Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Persistence.Context;
using Core.Repositories;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Utils;

namespace Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddPersistence()
                .AddRepositories()
                .AddIdentity();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<UsersDbContext>((serviceProvider, options) =>
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();

                var dbHost = Environment.GetEnvironmentVariable("DATABASE_SERVER");
                var dbPort = Environment.GetEnvironmentVariable("DATABASE_PORT");
                var dbName = Environment.GetEnvironmentVariable("DATABASE_NAME");
                var dbUser = Environment.GetEnvironmentVariable("DATABASE_USER");
                var dbPassword = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");

                var connectionString = "";

                if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbName) || string.IsNullOrEmpty(dbUser) || string.IsNullOrEmpty(dbPassword))
                    connectionString = configuration.GetConnectionString("DefaultConnection");
                else
                    connectionString = $"server={dbHost};port={dbPort};database={dbName};user={dbUser};password={dbPassword}";

                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<IRevenueRepository, RevenueRepository>();
            services.AddScoped<IFarmRepository, FarmRepository>();
            services.AddScoped<IHarvestRepository, HarvestRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<IPlotRepository, PlotRepository>();

            return services;
        }

        private static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromMinutes(15));

            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
            .AddEntityFrameworkStores<UsersDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IPasswordHasher<User>, BcryptPasswordHasherService<User>>();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY") ?? configuration["Jwt:Key"]!));
                var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? configuration["Jwt:Issuer"];
                var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? configuration["Jwt:Audience"];
                var jwtExpireMinutes = Environment.GetEnvironmentVariable("JWT_EXPIRATION_IN_MINUTES") ?? configuration["Jwt:ExpirationInMinutes"];

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    RequireExpirationTime = true,
                    IssuerSigningKey = key,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            })
            .AddGoogle(options =>
            {
                var configuration = services.BuildServiceProvider().GetService<IConfiguration>()!;

                options.ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID") ?? configuration!.GetSection("Google:ClientId").Value!;
                options.ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET") ?? configuration.GetSection("Google:ClientSecret").Value!;
            });

            return services;
        }
    }
}