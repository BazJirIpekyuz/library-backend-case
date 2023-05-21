using LibraryManagement.Library.Models;

namespace LibraryManagement.Library.Tests.Shared
{
    public static class BooksLocationTestData
    {
        public static Dictionary<string, LibraryItemLocation> Data =
            new Dictionary<string, LibraryItemLocation>()
            {
                {"978-3-16-148410-1", new LibraryItemLocation(){RoomId=1,RowId=1,BookShelfId=1 } },
                {"978-3-16-148410-2",new LibraryItemLocation(){RoomId=1,RowId=1,BookShelfId=2 } },
                {"978-3-16-148410-3",new LibraryItemLocation(){RoomId=1,RowId=1,BookShelfId=3 } },
                {"978-3-16-148410-4",new LibraryItemLocation(){RoomId=2,RowId=2,BookShelfId=4 } },
                {"978-3-16-148410-5",new LibraryItemLocation(){RoomId=2,RowId=2,BookShelfId=5 } },
            };
    }
}
