using BibliotekaAplikacjaProjekt.Services;

namespace BibliotekaAplikacjaProjekt.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBookstoreServices(this IServiceCollection serviceCollection) 
        {
            serviceCollection.AddDbContext<BookstoreDbContext, BookstoreDbContext>();
            serviceCollection.AddTransient<BookService>();
            serviceCollection.AddTransient<OrderService>();
            return serviceCollection;
        }
    }
}
