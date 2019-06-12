using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MSBA.Context;
using MSBA.Model;

namespace MSBA
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions()
                    .AddDbContext<ProjectContext>(options => options.UseSqlServer(_configuration.GetConnectionString("dbContext")));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseMvc(x =>
            {
                x.MapRoute("default", "{pageIndex?}");
            });
        }
    }
}
