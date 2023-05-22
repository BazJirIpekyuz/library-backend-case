using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Library.Models
{
    public class BookDto: LibraryItemDto
    {
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
    }
}
