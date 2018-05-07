using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgParty.CookSousVide.Data.Model;
using ProgParty.CookSousVide.Data.Repository;
using ProgParty.CookSousVide.Interface.DataModel;
using ProgParty.CookSousVide.Interface.Repository;

namespace ProgParty.CookSousVide
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
            services.AddMvc();
            // Add the configuration singleton here
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IFoodItemRepository, FoodItemRepository>();
            services.AddSingleton<IFoodItemModel, FoodItemModel>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //    name: "home_route",
                //    template: "Home/{action}",
                //    defaults: new { controller = "Home", action = "Index" });

                //routes.MapRoute(
                //    name: "default_route",
                //    template: "{controller}",
                //    defaults: new { controller = "Home", action = "Index" });

                //routes.MapRoute(
                //    name: "fooditem_route",
                //    template: "{animalKind}/{subType}",
                //    defaults: new { controller = "FoodItem", action = "Show" });
            });
        }
    }
}
