
using AutoMapper;
using books_in_the_table.Models.DTOs.AuthorPublisher;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Profiles
{
    public class AuthorPublisherProfile : Profile
    {
        public AuthorPublisherProfile()
        {
            CreateMap<AddAuthorPublisherDto, AuthorPublisher>();
            CreateMap<AuthorPublisher, ReadAuthorPublisherDto>();
            CreateMap<UpdateAuthorPublisherDto, AuthorPublisher>();
        }
    }
}