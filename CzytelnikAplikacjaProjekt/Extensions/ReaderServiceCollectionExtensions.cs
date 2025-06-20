
using CzytelnikAplikacjaProjekt.Services;

namespace CzytelnikAplikacjaProjekt.Extensions
{
    public static class ReaderServiceCollectionExtensions
    {
        public static IServiceCollection AddReaderService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ReaderDbContext, ReaderDbContext>();
            serviceCollection.AddTransient<ReaderService>();

            return serviceCollection;
        }
    }
}
