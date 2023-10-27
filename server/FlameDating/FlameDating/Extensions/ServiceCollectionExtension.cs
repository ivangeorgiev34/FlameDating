using FlameDating.Core.Contracts;
using FlameDating.Core.Services;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Data;
using FlameDating.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace FlameDating.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
                .AddEntityFrameworkStores<FlameDatingDbContext>()
                .AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                //options.AddPolicy("LocalServer", policy =>
                //{
                //    policy.WithOrigins("http://127.0.0.1:5500")
                //    .AllowAnyMethod()
                //    .AllowAnyHeader();
                //});

                options.AddPolicy("LocalServer", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IPreferenceService, PreferenceService>();
        }
    }
}
