using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;

namespace LibraryManagement.Library.Services
{
    public interface IBookService
    {
        IReadOnlyCollection<BookDto> ReadBooks(string input);
        IReadOnlyCollection<BookDto> FindBooks(string searchString);
        LibraryItemLocation? FindBookLocation(string isbn);
    }
}
