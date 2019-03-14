using DotNetCore.Repository.Imp;
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
            services.AddScoped< IUserService, UserService>();
            services.AddScoped< IUserRepo, UserRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                var types = typeof(IUserService).Assembly.GetTypes();
                foreach (var type in types)
                {
                    await context.Response.WriteAsync($"{type.Name}\r\n");
                }


                var service = app.ApplicationServices.GetRequiredService<IUserService>();
                await context.Response.WriteAsync(service.GetUserName() + "\r\n<br>"+service.GetRandom());
                service = app.ApplicationServices.GetRequiredService<IUserService>();
                await context.Response.WriteAsync("\r\n<br>" + service.GetUserName() + "\r\n<br>" + service.GetRandom());
            });
//            app.Run(async (context) =>
//            {
//                var service = app.ApplicationServices.GetRequiredService<IUserService>();
//                await context.Response.WriteAsync(service.GetUserName() + "\r\n");
//            });
        }
    }
}
