using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;
using System.Linq.Expressions;

namespace LibraryManagement.Library.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> books = new List<Book>();

        public BookRepository() { }

        /// <summary>
        /// Add book list.
        /// </summary>
        /// <param name="books">books to add.</param>
        /// <returns>book list.</returns>
        public IReadOnlyCollection<Book> AddBooks(List<Book> books)
        {
            this.books.AddRange(books);

            return this.books.AsReadOnly();
        }

        /// <summary>
        /// Find books that satisfy the book search specification
        /// </summary>
        /// <param name="bookSearchSpecification">book search expression.</param>
        /// <returns>books that satisfy book search expression.</returns>
        public IReadOnlyCollection<Book> FindBooks(Expression<Func<Book, bool>> bookSearchExpression)
        {
            var result = books.Where(bookSearchExpression.Compile()).ToList().AsReadOnly();

            return result;
        }

        /// <summary>
        /// Find book by ISBN number.
        /// </summary>
        /// <param name="isbn">ISBN number.</param>
        /// <returns>book object of the given ISBN number.</returns>
        public Book? FindBook(string isbn)
        {
            return books?.Find(q => q.ISBN == isbn);
        }

        /// <summary>
        /// Find book location by isbn. 
        /// </summary>
        /// <param name="isbn">ISBN number.</param>
        /// <returns>book location.</returns>
        public LibraryItemLocation? FindBookLocation(string isbn)
        {
            return FindBook(isbn)?.Location;
        }
    }
}
