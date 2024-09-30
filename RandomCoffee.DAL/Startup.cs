using RandomCoffee.DAL;

namespace RandomCoffee.WEB
{
    public static class Startup
    {
        public static void StartupApplication(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDLA(configuration);
        }

    }
}
