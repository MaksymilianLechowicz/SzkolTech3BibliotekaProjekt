using PromocjeAplikacjaProjekt.Services;

namespace PromocjeAplikacjaProjekt.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCouponServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddDbContext<CouponDbContext, CouponDbContext>();
            serviceCollection.AddTransient<CouponService>();
            serviceCollection.AddTransient<PointService>();
            return serviceCollection;
        }
    }
}
