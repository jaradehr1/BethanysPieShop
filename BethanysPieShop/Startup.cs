using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // ASP.Net Core uses a simple built-in dependency injection system instead of instantiating classes
        // We're basically passing dependencies to the constructor (constructor injection)
        // This method will help us register and retrieve dependencies 
        public void ConfigureServices(IServiceCollection services)
        {
            // eveything is now modular, if I need something I need to enable it
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Identity API, it uses AppDbContext to store the information
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // The request pipeline consists out of a number of components chaned behind one another
        // Those components are called middleware components which will intercept or handle an 
        // incoming HTTP request. This request/response will be altered by those components
        // NOTE: the order of those components matters here!
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // use the following with dev env
            app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();
            // retrieve a file through a route in wwwroot folder
            app.UseStaticFiles();


            app.UseAuthentication();

            // If the routes are not configured, ASP.NET will use a default route (localhost)
            //app.UseMvcWithDefaultRoute();

            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
