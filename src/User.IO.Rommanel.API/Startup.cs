using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using User.IO.Rommanel.API.ResultSet;
using User.IO.Rommanel.CrossCutting.IoC;
using User.IO.Rommanel.Domain.Core.Notifications;

namespace User.IO.Rommanel.API
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
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            }).AddNewtonsoftJson(); 
            services.AddMvc(options => options.Filters.Add<DomainNotificationFilter>())
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddScoped<MethodResultNotification>();
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

          
        }


        private static void RegisterServices(IServiceCollection services)
        {
            NativeInjectorBootStapper.RegisterServices(services);
        }
    }
}
