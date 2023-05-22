using LibraryManagement.Library.Services;
using LibraryManagement.Library.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Library.Tests.Services
{
    [Collection(TestConstants.LibraryCollectionDefinition)]
    public class BookInventoryServiceShould
    {
        private readonly IBookInventoryService _bookInventoryService;
        private readonly LibraryFixture _libraryFixture;

        public BookInventoryServiceShould(LibraryFixture libraryFixture)
        {
            _bookInventoryService = libraryFixture.ServiceProvider.GetRequiredService<IBookInventoryService>();
            _libraryFixture = libraryFixture;
        }

        [Fact]
        public void Given_RoomId_When_RoomHasAnyInventory_Then_Return_InventoryList()
        {
            // Arrange
            int roomId = _libraryFixture.RoomsWithRegisteredBooks.First();

            // Act
            var inventoryList = _bookInventoryService.GetBookInventoryListByRoomId(roomId);

            // Assert
            Assert.NotEmpty(inventoryList);
        }

        [Fact]
        public void Given_RowId_When_RowHasAnyInventory_Then_Return_InventoryList()
        {
            // Arrange
            int rowId = _libraryFixture.RowsWithRegisteredBooks.Last();

            // Act
            var inventoryList = _bookInventoryService.GetBookInventoryListByRowId(rowId);

            // Assert
            Assert.NotEmpty(inventoryList);
        }

        [Fact]
        public void Given_BookShelfId_When_BookShelfHasAnyInventory_Then_Return_InventoryList()
        {
            // Arrange
            int bookShelfId = _libraryFixture.BookShelvesWithRegisteredBooks.First();

            // Act
            var inventoryList = _bookInventoryService.GetBookInventoryListByBookShelfId(bookShelfId);

            // Assert
            Assert.NotEmpty(inventoryList);
        }
    }
}
