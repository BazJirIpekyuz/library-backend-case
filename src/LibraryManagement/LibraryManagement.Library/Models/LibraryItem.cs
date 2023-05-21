namespace LibraryManagement.Library.Models
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public LibraryItemLocation? Location { get; set; }
    }
}
