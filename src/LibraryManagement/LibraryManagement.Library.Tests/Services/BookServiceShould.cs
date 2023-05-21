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
        private readonly LibraryFixture _libraryFixture;
        private readonly IBookService _bookService;

        public BookServiceShould(LibraryFixture libraryFixture, ITestOutputHelper outputHelper)
        {
            _libraryFixture = libraryFixture;

            _bookService = libraryFixture.ServiceProvider.GetRequiredService<IBookService>();
            outputHelper.WriteLine("Getting a Book Service instance succeeded.");
        }

        [Fact]
        public void Given_SearchString_When_BookHasMatched_Then_Return_BookList()
        {
            // Arrange.
            string authorsNameSearchKeyword = "Jensen";
            IEnumerable<Book> booksExpected = _libraryFixture.Books.Where(q => q.Authors.Any(q => q.Contains(authorsNameSearchKeyword))).OrderBy(q => q.ISBN);
            string searchString = $"*{authorsNameSearchKeyword}*";

            // Act
            var booksResult = _bookService.FindBooks(searchString).OrderBy(q => q.ISBN).ToList();

            // Assert
            int i = 0;
            foreach (var item in booksExpected)
            {
                Assert.True(item.ISBN == booksResult[i++].ISBN);
            }
        }

        [Fact]
        public void Given_ISBN_When_BookHasLocation_Then_Return_BookLocation()
        {
            // Arrange
            string isbn = _libraryFixture.BookISBNsWithRegisteredLocation.First();

            // Act
            var bookLocation = _bookService.FindBookLocation(isbn);

            // Assert
            Assert.NotNull(bookLocation);
        }
    }
}
