using FlameDating.Core.Contracts;
using FlameDating.Core.Services;
using FlameDating.Infrastructure.Common;
using FlameDating.Infrastructure.Data;
using FlameDating.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace FlameDating.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlameDatingDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FlameDatingConnectionString"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:ValidAudience"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                };
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            //Configure swagger ui to have option to add a bearer token 
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

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
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IChatService, ChatService>();
        }
    }
}
