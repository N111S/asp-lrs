namespace ConfigurationApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
		}

        public void Configure(IApplicationBuilder app)
        {

			app.UseRouting();
			app.UseEndpoints(endpoints =>
            {
				endpoints.MapControllerRoute(
	                name: "library",
	                pattern: "Library/{action=Index}/{id?}",
	                defaults: new { controller = "Library" });

			});

		}
    }
}
