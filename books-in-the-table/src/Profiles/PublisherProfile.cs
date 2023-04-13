using AutoMapper;
using books_in_the_table.Models.DTOs.Publisher;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Profiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<AddPublisherDto, Publisher>();
            CreateMap<Publisher, ReadPublisherDto>();
            CreateMap<UpdatePublisherDto, Publisher>();
        }
    }
}