using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FeesManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;

namespace FeesManagement
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options =>
                                    options.UseSqlServer(_config.GetConnectionString("FeeDBConnection")));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //services.AddMvc();

            /*
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            });
            */

            
            //services.AddSingleton<IRegRepository, MockRegRepository>();
            services.AddScoped<IRegRepository, SQLRegRepository>();
            services.AddScoped<ICourseRepository, SQLCourseRepository>();
            services.AddScoped<IFeesRepository, SQLFeesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(rotes => 
            {
                rotes.MapRoute("default", "{controller=Registration}/{action=Index}");
            });
        }
    }
}
