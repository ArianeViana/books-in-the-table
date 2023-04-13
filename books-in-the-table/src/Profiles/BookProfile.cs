
using AutoMapper;
using books_in_the_table.Models.DTOs.Book;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<AddBookDto, Book>();
            CreateMap<Book, ReadBookDto>();
            CreateMap<UpdateBookDto, Book>();
        }
    }
}