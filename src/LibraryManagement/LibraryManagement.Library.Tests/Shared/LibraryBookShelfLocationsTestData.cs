using LibraryManagement.Library.Entities;

namespace LibraryManagement.Library.Tests.Shared
{
    public static class LibraryBookShelfLocationsTestData
    {
        public static List<Room> Rooms = new List<Room>()
        {
            new Room()
            {
                Id= 1,
                RoomNumber="Room1",
                Rows= new List<Row>
                {
                    new Row()
                    {
                        Id= 1,
                        RoomId= 1,
                        BookShelves=new List<BookShelf>
                        {
                            new BookShelf()
                            {
                                Id= 1,
                                RowId= 1,
                                BookShelfNumber="B11"
                            },
                            new BookShelf()
                            {
                                Id= 2,
                                RowId= 1,
                                BookShelfNumber="B12"
                            },
                            new BookShelf()
                            {
                                Id= 3,
                                RowId= 1,
                                BookShelfNumber="B13"
                            }
                        }
                    }
                }
            },
            new Room()
            {
                Id= 2,
                RoomNumber="Room2",
                Rows= new List<Row>
                {
                    new Row()
                    {
                        Id= 2,
                        RoomId= 2,
                        BookShelves=new List<BookShelf>
                        {
                            new BookShelf()
                            {
                                Id= 4,
                                RowId= 2,
                                BookShelfNumber="B24"
                            },
                            new BookShelf()
                            {
                                Id= 5,
                                RowId= 2,
                                BookShelfNumber="B25"
                            },
                            new BookShelf()
                            {
                                Id= 6,
                                RowId= 2,
                                BookShelfNumber="B26"
                            }
                        }
                    }
                }
            }
        };
    }
}
