using AutoMapper;
using LibraryManagement.Library.Entities;
using LibraryManagement.Library.Models;

namespace LibraryManagement.Library.Profiles
{
    internal class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
