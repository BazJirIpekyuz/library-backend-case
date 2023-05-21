using LibraryManagement.Library.Models;

namespace LibraryManagement.Library.Services
{
    public interface IBookService
    {
        IReadOnlyCollection<Book> ReadBooks(string input);
        IReadOnlyCollection<Book> FindBooks(string searchString);
        LibraryItemLocation? FindBookLocation(string isbn);
    }
}
