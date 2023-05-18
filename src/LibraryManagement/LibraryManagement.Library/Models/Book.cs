namespace LibraryManagement.Library.Models
{
    public class Book : LibraryItem
    {
        public List<string> Authors { get; set; } = new List<string>();
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
    }
}
