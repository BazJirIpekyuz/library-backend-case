using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;

namespace LibraryManagement.Library.Repositories
{
    public class BookInventoryRepository : IBookInventoryRepository
    {
        private readonly IBookRepository bookRepository;
        // Lookup datastructures for fast lookup for book inventory list in a room, row or book-shelf.
        private Dictionary<int, Room> libraryRoomsLookup = new Dictionary<int, Room>();
        private Dictionary<int, Row> libraryRowsLookup = new Dictionary<int, Row>();
        private Dictionary<int, BookShelf> libraryBookShelvesLookup = new Dictionary<int, BookShelf>();

        public BookInventoryRepository(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        /// <summary>
        /// Register book location.
        /// </summary>
        /// <param name="isbn">ISBN number.</param>
        /// <param name="room">room number.</param>
        /// <param name="row">row number.</param>
        /// <param name="bookShelf">book-shelf number. </param>
        /// <exception cref="ArgumentException"></exception>
        public void RegisterBook(string isbn, int room, int row, int bookShelf)
        {
            var book = bookRepository.FindBook(isbn);

            if (book == null)
            {
                throw new ArgumentException("A book not found with ISBN number.", isbn);
            }
            // Set book location.
            book.Location = new LibraryItemLocation()
            {
                RoomId = room,
                RowId = row,
                BookShelfId = bookShelf
            };

            libraryBookShelvesLookup[bookShelf].Books.Add(book);
        }

        /// <summary>
        /// Get book inventory list of the given room.
        /// </summary>
        /// <param name="roomId">room id.</param>
        /// <returns>book list.</returns>
        public IReadOnlyCollection<Book> GetBookInventoryListByRoomId(int roomId)
        {
            return libraryRoomsLookup[roomId].Books.AsReadOnly();
        }

        /// <summary>
        /// Get book inventory list of the given row.
        /// </summary>
        /// <param name="rowId">row id in a room.</param>
        /// <returns>book list.</returns>
        public IReadOnlyCollection<Book> GetBookInventoryListByRowId(int rowId)
        {
            return libraryRowsLookup[rowId].Books.AsReadOnly();
        }

        /// <summary>
        /// Get inventory list of the given book-shelf.
        /// </summary>
        /// <param name="bookShelfId">book-shelf id.</param>
        /// <returns>book list.</returns>
        public IReadOnlyCollection<Book> GetBookInventoryListByBookShelfId(int bookShelfId)
        {
            return libraryBookShelvesLookup[bookShelfId].Books.AsReadOnly();
        }

        /// <summary>
        /// Register library rooms, room's rows and rows's book-shelves.
        /// </summary>
        /// <param name="rooms">rooms.</param>
        public void RegisterLibraryLocations(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                libraryRoomsLookup.Add(room.Id, room);
                AddLibraryRoomRows(room.Rows);
            }
        }

        private void AddLibraryRoomRows(List<Row> rows)
        {
            foreach (var roomRow in rows)
            {
                libraryRowsLookup.Add(roomRow.Id, roomRow);
                AddLibraryRowBookShelvesLookup(roomRow.BookShelves);
            }
        }

        private void AddLibraryRowBookShelvesLookup(List<BookShelf> bookShelves)
        {
            foreach (var bookShelf in bookShelves)
            {
                libraryBookShelvesLookup.Add(bookShelf.Id, bookShelf);
            }
        }
    }
}
