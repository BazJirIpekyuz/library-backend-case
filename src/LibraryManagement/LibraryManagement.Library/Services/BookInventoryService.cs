using LibraryManagement.Library.Models;
using LibraryManagement.Library.Repositories;

namespace LibraryManagement.Library.Services
{
    public class BookInventoryService : IBookInventoryService
    {
        private readonly IBookInventoryRepository bookInventoryRepository;

        public BookInventoryService(IBookInventoryRepository bookInventoryRepository)
        {
            this.bookInventoryRepository = bookInventoryRepository;
        }

        public void RegisterBook(string isbn, int room, int row, int bookShelf)
        {
            bookInventoryRepository.RegisterBook(isbn, room, row, bookShelf);
        }

        public List<Room> RegisterLibraryLocations(List<Room> rooms)
        {
            return bookInventoryRepository.RegisterLibraryLocations(rooms);
        }

        public List<Book> GetBookInventoryListByRoomId(int roomId)
        {
            return bookInventoryRepository.GetBookInventoryListByRoomId(roomId);
        }

        public List<Book> GetBookInventoryListByRowId(int rowId)
        {
            return bookInventoryRepository.GetBookInventoryListByRowId(rowId);
        }

        public List<Book> GetBookInventoryListByBookShelfId(int bookShelfId)
        {
            return bookInventoryRepository.GetBookInventoryListByBookShelfId(bookShelfId);
        }
    }
}
