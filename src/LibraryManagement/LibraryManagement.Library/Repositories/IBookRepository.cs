using LibraryManagement.Library.Models;
using System.Linq.Expressions;

namespace LibraryManagement.Library.Repositories
{
    public interface IBookRepository
    {
        public List<Book> AddBooks(List<Book> books);
        List<Book> FindBooks(Expression<Func<Book, bool>> bookSearchExpression);
        Book? FindBookByISBN(string isbn);
        LibraryItemLocation? FindBookLocationByISBN(string isbn);
    }
}
