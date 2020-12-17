using Rent.Data;
using Rent.Logic;
using Rent.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Rent.WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc((opt) => opt.EnableEndpointRouting = false);
            services.AddTransient<RentRepository, RentRepository>();
            services.AddTransient<VideoGameRepository, VideoGameRepository>();
            services.AddTransient<PersonRepository, PersonRepository>();
            services.AddTransient<RentLogic, RentLogic>();
            services.AddTransient<VideoGameLogic, VideoGameLogic>();
            services.AddTransient<PersonLogic, PersonLogic>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseMvcWithDefaultRoute();
        }
    }
}
