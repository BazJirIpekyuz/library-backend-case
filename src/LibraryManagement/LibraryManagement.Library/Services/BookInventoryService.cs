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

        public void RegisterLibraryLocations(List<Room> rooms)
        {
            bookInventoryRepository.RegisterLibraryLocations(rooms);
        }

        public IReadOnlyCollection<Book> GetBookInventoryListByRoomId(int roomId)
        {
            return bookInventoryRepository.GetBookInventoryListByRoomId(roomId);
        }

        public IReadOnlyCollection<Book> GetBookInventoryListByRowId(int rowId)
        {
            return bookInventoryRepository.GetBookInventoryListByRowId(rowId);
        }

        public IReadOnlyCollection<Book> GetBookInventoryListByBookShelfId(int bookShelfId)
        {
            return bookInventoryRepository.GetBookInventoryListByBookShelfId(bookShelfId);
        }
    }
}
