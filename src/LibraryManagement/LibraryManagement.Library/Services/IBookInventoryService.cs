using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;

namespace LibraryManagement.Library.Services
{
    public interface IBookInventoryService
    {
        void RegisterBook(string isbn, int room, int row, int bookShelf);
        IReadOnlyCollection<BookDto> GetBookInventoryListByRoomId(int roomId);
        IReadOnlyCollection<BookDto> GetBookInventoryListByRowId(int rowId);
        IReadOnlyCollection<BookDto> GetBookInventoryListByBookShelfId(int bookShelfId);
        void RegisterLibraryLocations(List<Room> rooms);
    }
}
