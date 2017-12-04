using System;
using Core.BuddyList;
using Core.BuddyList.Plugins;
using Core.PlayInvitations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Providers;
using Repository.Stores;

namespace Web
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
            services.AddScoped<IProvideBuddies>(buidesProvider);
            services.AddScoped<IListBuddies>(listBuddies);
            services.AddSingleton<MtbDbContext>(mtbStore);
            services.AddScoped<IAddBuddy>(addBuddy);
            services.AddScoped<IStoreBuddies>(storeBuddies);
            services.AddScoped<IStorePlayInvitations>(storePlayInvitations);
            services.AddScoped<IProvidePlayInvitations>(providePlayInvitations);
            services.AddMvc();
        }

        private IProvidePlayInvitations providePlayInvitations(IServiceProvider arg)
        {
            return new PlayInvitationsProvider(arg.GetService<MtbDbContext>());
        }

        private IStorePlayInvitations storePlayInvitations(IServiceProvider arg)
        {
            return new PlayInvitationsStore(arg.GetService<MtbDbContext>());
        }


        private MtbDbContext mtbStore(IServiceProvider arg)
        {
            return new MtbDbContext();
        }

        private IStoreBuddies storeBuddies(IServiceProvider arg)
        {
            var userId =new Guid("00000000-0000-0000-0000-000000000000");
            return new BuddyStore(arg.GetService<MtbDbContext>(), userId );
        }

        private IAddBuddy addBuddy(IServiceProvider arg)
        {
            return new AddBuddy(arg.GetService<IStoreBuddies>(), arg.GetService<IProvideBuddies>());
        }

        private IListBuddies listBuddies(IServiceProvider arg)
        {
            return new ListBuddies(arg.GetService<IProvideBuddies>());
        }

        private IProvideBuddies buidesProvider(IServiceProvider arg)
        {
            var userId =new Guid("00000000-0000-0000-0000-000000000000");
            return new BuddiesProvider(arg.GetService<MtbDbContext>(), userId);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
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

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
