using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;
using System.Linq.Expressions;

namespace LibraryManagement.Library.Repositories
{
    public interface IBookRepository
    {
        IReadOnlyCollection<Book> AddBooks(List<Book> books);
        IReadOnlyCollection<Book> FindBooks(Expression<Func<Book, bool>> bookSearchExpression);
        Book? FindBook(string isbn);
        LibraryItemLocation? FindBookLocation(string isbn);
    }
}
