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
        List<Book> GetBookInventoryListByRoomId(int roomId);
        List<Book> GetBookInventoryListByRowId(int rowId);
        List<Book> GetBookInventoryListByBookShelfId(int bookShelfId);
        List<Room> RegisterLibraryLocations(List<Room> rooms);
    }
}
