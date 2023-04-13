
using AutoMapper;
using books_in_the_table.Models.DTOs.Author;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AddAuthorDto, Author>();
            CreateMap<Author, ReadAuthorDto>();
            CreateMap<UpdateAuthorDto, Author>();
        }
    }
}