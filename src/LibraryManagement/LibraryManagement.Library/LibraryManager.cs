using LibraryManagement.Library.Helpers;
using LibraryManagement.Library.Models;
using LibraryManagement.Library.TextParsers;

namespace LibraryManagement.Library
{
    public class LibraryManager
    {
        private List<Book> books = new List<Book>();

        public LibraryManager()
        {
        }

        /// <summary>
        /// Create a book list from book data input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Book> ReadBooks(string input)
        {
            var list = BookInputTextParser.Parse(input);
            books.AddRange(list);

            return books;
        }

        /// <summary>
        /// Find books that satisfies the values in the search string.
        /// </summary>
        /// <param name="searchString">search string.</param>
        /// <returns>books that satisfies search keywords.</returns>
        public List<Book> FindBooks(string searchString)
        {
            // Build book search predicate.
            Func<Book, bool> searchPredicate = BookSearchPredicateBuilder.Build(searchString).Compile();
            var result = books.Where(searchPredicate).ToList();

            return result;
        }

    }
}
