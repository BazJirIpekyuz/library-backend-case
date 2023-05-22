namespace LibraryManagement.Library.Entities
{
    public class Row
    {
        public int Id { get; set; }
        public string RowNumber { get; set; }
        public int RoomId { get; set; }
        public List<BookShelf> BookShelves { get; set; }

        public List<Book> Books => BookShelves.SelectMany(x => x.Books).ToList();
    }
}
