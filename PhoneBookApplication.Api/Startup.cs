using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhoneBookApplication.Data;
using PhoneBookApplication.Domain.CommandHandlers;
using PhoneBookApplication.Domain.Commands;
using PhoneBookApplication.Domain.Entities;
using PhoneBookApplication.Domain.Queries;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PhoneBookContext>
             (options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<ICommandHandler<CreatePhoneBookCommand>, CreatePhoneBookCommandHandler>();
            services.AddScoped<ICommandHandler<InsertEntryCommand>, InsertEntryCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteEntryCommand>, DeleteEntryCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateEntryCommand>, UpdateEntryCommandHandler>();
            services.AddScoped<IQueryHandler<GetPhoneBooksQuery, IEnumerable<PhoneBookAggregateRoot>>, GetGetPhoneBooksQueryHandler>();
            services.AddScoped<IQueryHandler<SearchPhoneBookQuery, IEnumerable<Entry>>, SearchPhoneBookQueryHandler>();

            services.AddSingleton<Messages>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
