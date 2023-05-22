namespace LibraryManagement.Library.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public List<Row> Rows { get; set; }

        public List<Book> Books => Rows.SelectMany(x => x.Books).ToList();
    }
}
