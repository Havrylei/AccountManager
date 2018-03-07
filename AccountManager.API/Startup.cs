using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AccountManager.DAL.Infrastructure;
using AccountManager.DAL.Interfaces;
using AccountManager.DAL.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using AccountManager.BLL.Infrastructure;
using AccountManager.BLL.Interfaces;
using AccountManager.BLL.Services;
using AccountManager.BLL.Infrastructure.Profiles;
using Microsoft.AspNetCore.Identity;
using AccountManager.DAL.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using AccountManager.API.Models;
using AccountManager.API.Infrastructure.Filters;

namespace AccountManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DBConnection");
                      
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole>(opts => {
                    opts.Password.RequiredLength = 5;   
                    opts.Password.RequireNonAlphanumeric = false;  
                    opts.Password.RequireLowercase = false; 
                    opts.Password.RequireUppercase = false; 
                    opts.Password.RequireDigit = false; 
                })
                .AddEntityFrameworkStores<UserContext>();

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
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = AuthOptions.ISSUER,

                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = AuthOptions.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,

                            // установка ключа безопасности
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
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
            
            //app.UseSwagger();
            
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/app/swagger.json", "Account Manager");
            //});

            app.UseMvc();
        }
    }
}
