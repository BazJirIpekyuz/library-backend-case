using LibraryManagement.Library.Extensions;
using LibraryManagement.Library.Models;
using LibraryManagement.Library.Services;
using LibraryManagement.Library.Tests.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Library.Tests.Helpers
{
    public class LibraryFixture : IDisposable
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<string> BookISBNsWithRegisteredLocation { get; private set; } = new List<string>();
        public List<int> RoomsWithRegisteredBooks = new List<int>();
        public List<int> RowsWithRegisteredBooks = new List<int>();
        public List<int> BookShelvesWithRegisteredBooks = new List<int>();

        public LibraryFixture()
        {
            ServiceProvider = GetServiceProvider();
            InitializeCollectionsWithTestData();
        }

        private void InitializeCollectionsWithTestData()
        {
            try
            {
                var bookService = ServiceProvider.GetRequiredService<IBookService>();
                var bookInventoryService = ServiceProvider.GetRequiredService<IBookInventoryService>();

                // Add rooms.
                bookInventoryService.RegisterLibraryLocations(LibraryBookShelfLocationsTestData.Rooms);

                // Add books.
                string booksTestDataInput = File.ReadAllText("BooksTestData.txt");
                IReadOnlyCollection<Book> books = bookService.ReadBooks(booksTestDataInput);
                Books.AddRange(books);

                // Add books locations.
                foreach (var bltd in BooksLocationTestData.Data)
                {
                    bookInventoryService.RegisterBook(bltd.Key, bltd.Value.RoomId, bltd.Value.RowId, bltd.Value.BookShelfId);
                    BookISBNsWithRegisteredLocation.Add(bltd.Key);
                }

                RoomsWithRegisteredBooks.AddRange(BooksLocationTestData.Data.Values.Select(q => q.RoomId).Distinct());
                RowsWithRegisteredBooks.AddRange(BooksLocationTestData.Data.Values.Select(q => q.RowId).Distinct());
                BookShelvesWithRegisteredBooks.AddRange(BooksLocationTestData.Data.Values.Select(q => q.BookShelfId).Distinct());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private ServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLibraryServices();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }

        public void Dispose()
        {
            // Cleanup
        }
    }
}
