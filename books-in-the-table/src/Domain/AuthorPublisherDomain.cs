using AutoMapper;
using books_in_the_table.Data;
using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.AuthorPublisher;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Domain
{
    public class AuthorPublisherDomain : IAuthorPublisher
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorPublisherDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAuthorPublisherDto Add(AddAuthorPublisherDto dto)
        {
            AuthorPublisher authorPublisherModel = _mapper.Map<AuthorPublisher>(dto);
            _context.AuthorPublishers.Add(authorPublisherModel);
            _context.SaveChanges();
            ReadAuthorPublisherDto authorPublisherDto = _mapper.Map<ReadAuthorPublisherDto>(authorPublisherModel);

            return authorPublisherDto;
        }

        public bool Delete(Guid id)
        {
            AuthorPublisher authorPublisher = _context.AuthorPublishers.FirstOrDefault(ap => ap.Id == id);

            if (authorPublisher != null)
            {
                _context.Remove(authorPublisher);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<ReadAuthorPublisherDto> SearchAll()
        {
            var authorPublishers = _context.AuthorPublishers.ToList();
            IEnumerable<ReadAuthorPublisherDto> authorPublishersDto = _mapper.Map<List<ReadAuthorPublisherDto>>(authorPublishers);

            return authorPublishersDto;
        }

        public ReadAuthorPublisherDto SearchById(Guid id)
        {
            AuthorPublisher authorPublisher = _context.AuthorPublishers.FirstOrDefault(ap => ap.Id == id);
            ReadAuthorPublisherDto authorPublisherDto = _mapper.Map<ReadAuthorPublisherDto>(authorPublisher);

            return authorPublisherDto;
        }

        public ReadAuthorPublisherDto Update(Guid id, UpdateAuthorPublisherDto dto)
        {
            AuthorPublisher authorPublisher = _context.AuthorPublishers.FirstOrDefault(ap => ap.Id == id);

            if (authorPublisher != null)
            {
                _mapper.Map(dto, authorPublisher);
                _context.SaveChanges();
                ReadAuthorPublisherDto authorPublisherDto = _mapper.Map<ReadAuthorPublisherDto>(authorPublisher);

                return authorPublisherDto;
            }

            return null;
        }
    }
}