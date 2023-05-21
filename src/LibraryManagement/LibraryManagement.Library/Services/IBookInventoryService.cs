using LibraryManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Library.Services
{
    public interface IBookInventoryService
    {
        void RegisterBook(string isbn, int room, int row, int bookShelf);
        IReadOnlyCollection<Book> GetBookInventoryListByRoomId(int roomId);
        IReadOnlyCollection<Book> GetBookInventoryListByRowId(int rowId);
        IReadOnlyCollection<Book> GetBookInventoryListByBookShelfId(int bookShelfId);
        void RegisterLibraryLocations(List<Room> rooms);
    }
}
