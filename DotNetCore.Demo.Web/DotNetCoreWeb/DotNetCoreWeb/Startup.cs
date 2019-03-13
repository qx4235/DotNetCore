using DotNetCore.Repository.Interface;
using DotNetCore.Service.Imp;
using DotNetCore.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton< IUserService, UserService>();
//            services.AddSingleton< IUserRepo, IUserRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context,func) =>
            {
                var service = app.ApplicationServices.GetRequiredService<IUserService>();
                await context.Response.WriteAsync(service.GetRandom() + "\r\n");
            });
            app.Run(async (context) =>
            {
                var service = app.ApplicationServices.GetRequiredService<IUserService>();
                await context.Response.WriteAsync(service.GetRandom() + "\r\n");
            });
        }
    }
}
