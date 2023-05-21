using LibraryManagement.Library.Services;
using LibraryManagement.Library.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Library.Tests.Services
{
    [Collection(TestConstants.LibraryCollectionDefinition)]
    public class BookInventoryServiceShould
    {
        private readonly IBookInventoryService bookInventoryService;
        private readonly LibraryFixture libraryFixture;

        public BookInventoryServiceShould(LibraryFixture libraryFixture)
        {
            bookInventoryService = libraryFixture.ServiceProvider.GetRequiredService<IBookInventoryService>();
            this.libraryFixture = libraryFixture;
        }

        [Fact]
        public void GetInventoryListByRoomId()
        {
            // Arrange
            int roomId = libraryFixture.RoomsWithRegisteredBooks.First();

            // Act
            var inventoryList = bookInventoryService.GetBookInventoryListByRoomId(roomId);

            // Assert
            Assert.NotEmpty(inventoryList);
            Assert.True(!inventoryList.Any(q => q.Location?.RoomId != roomId));
        }

        [Fact]
        public void GetInventoryListByRowId()
        {
            // Arrange
            int rowId = libraryFixture.RowsWithRegisteredBooks.Last();

            // Act
            var inventoryList = bookInventoryService.GetBookInventoryListByRowId(rowId);

            // Assert
            Assert.NotEmpty(inventoryList);
            Assert.True(!inventoryList.Any(q => q.Location?.RowId != rowId));
        }

        [Fact]
        public void GetBookInventoryListByBookShelfId()
        {
            // Arrange
            int bookShelfId = libraryFixture.BookShelvesWithRegisteredBooks.First();

            // Act
            var inventoryList = bookInventoryService.GetBookInventoryListByBookShelfId(bookShelfId);

            // Assert
            Assert.NotEmpty(inventoryList);
            Assert.True(!inventoryList.Any(q => q.Location?.RowId != bookShelfId));
        }
    }
}
