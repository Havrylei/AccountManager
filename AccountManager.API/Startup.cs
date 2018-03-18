using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;
using AccountManager.DAL.Repositories;
using AccountManager.BLL.Infrastructure;
using AccountManager.BLL.Interfaces;
using AccountManager.BLL.Services;
using AccountManager.BLL.Infrastructure.Profiles;
using AccountManager.DAL.Entities;
using AccountManager.API.Models;
using AccountManager.API.Infrastructure.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace AccountManager.API
{
    public class Startup
    {
        public const string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DBConnection");

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    b => b.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));

            IdentityBuilder builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 5;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);

            builder.AddEntityFrameworkStores<UserContext>().AddDefaultTokenProviders();
            services.AddSingleton(MapperProfile.Instance);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRatingService, UserRatingService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("app", new Info { Title = "Account Manager" });
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/app/swagger.json", "Account Manager");
            });
            app.UseMvc();
        }
    }
}
