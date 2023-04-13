using AutoMapper;
using books_in_the_table.Data;
using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.Publisher;
using books_in_the_table.Models.Entities;


namespace books_in_the_table.Domain
{
    public class PublisherDomain : IPublisher
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PublisherDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadPublisherDto Add(AddPublisherDto dto)
        {
            Publisher publisherModel = _mapper.Map<Publisher>(dto);
            _context.Publishers.Add(publisherModel);
            _context.SaveChanges();
            ReadPublisherDto publisherDto = _mapper.Map<ReadPublisherDto>(publisherModel);

            return publisherDto;
        }

        public bool Delete(Guid id)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(publisher => publisher.Id == id);

            if (publisher != null)
            {
                _context.Remove(publisher);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<ReadPublisherDto> SearchAll()
        {
            var publisher = _context.Publishers.ToList();
            IEnumerable<ReadPublisherDto> publishersDto = _mapper.Map<List<ReadPublisherDto>>(publisher);

            return publishersDto;
        }

        public ReadPublisherDto SearchById(Guid id)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(publisher => publisher.Id == id);
            ReadPublisherDto publisherDto = _mapper.Map<ReadPublisherDto>(publisher);

            return publisherDto;
        }

        public ReadPublisherDto Update(Guid id, UpdatePublisherDto dto)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(publisher => publisher.Id == id);

            if (publisher != null)
            {
                _mapper.Map(dto, publisher);
                _context.SaveChanges();
                ReadPublisherDto publisherDto = _mapper.Map<ReadPublisherDto>(publisher);

                return publisherDto;
            }

            return null;
        }
    }
}