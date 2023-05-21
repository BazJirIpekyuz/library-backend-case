using LibraryManagement.Library.Helpers;
using LibraryManagement.Library.Models;
using LibraryManagement.Library.Repositories;
using LibraryManagement.Library.TextParsers;

namespace LibraryManagement.Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IInputTextParser<Book> bookInputTextParser;

        public BookService(IBookRepository bookRepository, IInputTextParser<Book> bookInputTextParser)
        {
            this.bookRepository = bookRepository;
            this.bookInputTextParser = bookInputTextParser;
        }

        /// <summary>
        /// Create a book list from book data input.
        /// </summary>
        /// <param name="input">book input data.</param>
        /// <returns>book list.</returns>
        public List<Book> ReadBooks(string input)
        {
            var bookList = bookInputTextParser.Parse(input);

            return bookRepository.AddBooks(bookList);
        }

        /// <summary>
        /// Find books that satisfies the values in the search string.
        /// </summary>
        /// <param name="searchString">search string.</param>
        /// <returns>books that satisfies search keywords.</returns>
        public List<Book> FindBooks(string searchString)
        {
            var keywords = SearchStringParser.Parse(searchString);
            return bookRepository.FindBooks(BookSearchPredicateBuilder.Build(keywords));
        }

        /// <summary>
        /// Find library item location.
        /// </summary>
        /// <param name="isbn">ISBN number.</param>
        /// <returns>book location.</returns>
        public LibraryItemLocation? FindBookLocationByISBN(string isbn)
        {
            return bookRepository.FindBookLocationByISBN(isbn);
        }
    }
}
