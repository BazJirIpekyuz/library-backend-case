using LibraryManagement.Library.Models;
using LibraryManagement.Library.Repositories;
using LibraryManagement.Library.Services;
using LibraryManagement.Library.TextParsers;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Library.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLibraryServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBookService, BookService>();
            serviceCollection.AddScoped<IBookInventoryService, BookInventoryService>();
            serviceCollection.AddSingleton<IBookRepository, BookRepository>();
            serviceCollection.AddSingleton<IBookInventoryRepository, BookInventoryRepository>();
            serviceCollection.AddSingleton<IInputTextParser<Book>, BookInputTextParser>();

            return serviceCollection;
        }
    }
}
