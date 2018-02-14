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

namespace AccountManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddSingleton(MapperProfile.Instance);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("app", new Info { Title = "Account Manager" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/app/swagger.json", "Account Manager");
            });

            app.UseMvc();
        }
    }
}
