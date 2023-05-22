using AutoMapper;
using LibraryManagement.Library.Entities;
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
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IInputTextParser<Book> bookInputTextParser, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.bookInputTextParser = bookInputTextParser;
            this.mapper = mapper;
        }

        /// <summary>
        /// Create a book list from book data input.
        /// </summary>
        /// <param name="input">book input data.</param>
        /// <returns>book list.</returns>
        public IReadOnlyCollection<BookDto> ReadBooks(string input)
        {
            var bookList = bookInputTextParser.Parse(input);

            return mapper.Map<IReadOnlyCollection<BookDto>>(bookRepository.AddBooks(bookList));
        }

        /// <summary>
        /// Find books that satisfies the values in the search string.
        /// </summary>
        /// <param name="searchString">search string.</param>
        /// <returns>books that satisfies search keywords.</returns>
        public IReadOnlyCollection<BookDto> FindBooks(string searchString)
        {
            var keywords = SearchStringParser.Parse(searchString);
            var foundBooks = bookRepository.FindBooks(BookSearchPredicateBuilder.Build(keywords));

            return mapper.Map<IReadOnlyCollection<BookDto>>(foundBooks);
        }

        /// <summary>
        /// Find library item location.
        /// </summary>
        /// <param name="isbn">ISBN number.</param>
        /// <returns>book location.</returns>
        public LibraryItemLocation? FindBookLocation(string isbn)
        {
            return bookRepository.FindBookLocation(isbn);
        }
    }
}
