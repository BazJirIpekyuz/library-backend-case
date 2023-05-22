using AutoMapper;
using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;
using LibraryManagement.Library.Repositories;

namespace LibraryManagement.Library.Services
{
    public class BookInventoryService : IBookInventoryService
    {
        private readonly IBookInventoryRepository bookInventoryRepository;
        private readonly IMapper mapper;

        public BookInventoryService(IBookInventoryRepository bookInventoryRepository, IMapper mapper)
        {
            this.bookInventoryRepository = bookInventoryRepository;
            this.mapper = mapper;
        }

        public void RegisterBook(string isbn, int room, int row, int bookShelf)
        {
            bookInventoryRepository.RegisterBook(isbn, room, row, bookShelf);
        }

        public void RegisterLibraryLocations(List<Room> rooms)
        {
            bookInventoryRepository.RegisterLibraryLocations(rooms);
        }

        public IReadOnlyCollection<BookDto> GetBookInventoryListByRoomId(int roomId)
        {
            var roomBookInventory = bookInventoryRepository.GetBookInventoryListByRoomId(roomId);

            return mapper.Map<IReadOnlyCollection<BookDto>>(roomBookInventory);
        }

        public IReadOnlyCollection<BookDto> GetBookInventoryListByRowId(int rowId)
        {
            var rowBookInventory = bookInventoryRepository.GetBookInventoryListByRowId(rowId);

            return mapper.Map<IReadOnlyCollection<BookDto>>(rowBookInventory);
        }

        public IReadOnlyCollection<BookDto> GetBookInventoryListByBookShelfId(int bookShelfId)
        {
            var bookShelfBookInventory = bookInventoryRepository.GetBookInventoryListByBookShelfId(bookShelfId);

            return mapper.Map<IReadOnlyCollection<BookDto>>(bookShelfBookInventory);
        }
    }
}
