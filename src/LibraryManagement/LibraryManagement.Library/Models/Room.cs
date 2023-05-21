namespace LibraryManagement.Library.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public List<Row> Rows { get; set; }

        internal List<Book> Books => Rows.SelectMany(x => x.Books).ToList();
    }
}
