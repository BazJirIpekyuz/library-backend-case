using LibraryManagement.Library.Models;
using LibraryManagement.Library.Services;
using LibraryManagement.Library.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace LibraryManagement.Library.Tests.Services
{
    [Collection(TestConstants.LibraryCollectionDefinition)]
    public class BookServiceShould
    {
        private readonly LibraryFixture libraryFixture;
        private readonly IBookService bookService;

        public BookServiceShould(LibraryFixture libraryFixture, ITestOutputHelper outputHelper)
        {
            this.libraryFixture = libraryFixture;

            bookService = libraryFixture.ServiceProvider.GetRequiredService<IBookService>();
            outputHelper.WriteLine("Getting a Book Service instance succeeded.");
        }

        [Fact]
        public void FindBooksBySearchString()
        {
            // Arrange.
            string authorsNameSearchKeyword = "Jensen";
            IEnumerable<Book> booksExpected = libraryFixture.Books.Where(q => q.Authors.Any(q => q.Contains(authorsNameSearchKeyword))).OrderBy(q => q.ISBN);
            string searchString = $"*{authorsNameSearchKeyword}*";

            // Act
            var booksResult = bookService.FindBooks(searchString).OrderBy(q => q.ISBN).ToList();

            // Assert
            int i = 0;
            foreach (var item in booksExpected)
            {
                Assert.True(item.ISBN == booksResult[i++].ISBN);
            }
        }

        [Fact]
        public void FindBookLocationByISBN()
        {
            // Arrange
            string isbn = libraryFixture.BookISBNsWithRegisteredLocation.First();

            // Act
            var bookLocation = bookService.FindBookLocationByISBN(isbn);

            // Assert
            Assert.NotNull(bookLocation);
        }
    }
}
