using LibraryManagement.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Library.Services
{
    public interface IBookService
    {
        List<Book> ReadBooks(string input);
        List<Book> FindBooks(string searchString);
        LibraryItemLocation? FindBookLocationByISBN(string isbn);
    }
}
