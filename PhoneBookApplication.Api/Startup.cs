using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBookApplication.Data;
using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.QueryHandlers;
using PhoneBookApplication.Domain.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace PhoneBookApplication.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PhoneBookContext>
             (options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IPhoneBookRepository, PhoneBookRepository>();
            services.AddCommandQueryHandlers(typeof(IQueryHandler<,>), "PhoneBookApplication.Domain");
            services.AddCommandQueryHandlers(typeof(ICommandHandler<>), "PhoneBookApplication.Domain");

            services.AddSingleton<IMediator, Mediator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
