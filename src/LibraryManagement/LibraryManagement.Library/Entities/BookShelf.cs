namespace LibraryManagement.Library.Entities
{
    public class BookShelf
    {
        public int Id { get; set; }
        public int RowId { get; set; }
        public string BookShelfNumber { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}