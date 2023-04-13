
using AutoMapper;
using books_in_the_table.Data;
using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.Author;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Domain
{
    public class AuthorDomain : IAuthor
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadAuthorDto Add(AddAuthorDto dto)
        {
            Author authorModel = _mapper.Map<Author>(dto);
            _context.Authors.Add(authorModel);
            _context.SaveChanges();
            ReadAuthorDto authorDto = _mapper.Map<ReadAuthorDto>(authorModel);

            return authorDto;
        }

        public bool Delete(Guid id)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);

            if (author != null)
            {
                _context.Remove(author);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<ReadAuthorDto> SearchAll()
        {
            var authors = _context.Authors.ToList();
            IEnumerable<ReadAuthorDto> authorsDto = _mapper.Map<List<ReadAuthorDto>>(authors);

            return authorsDto;
        }

        public ReadAuthorDto SearchById(Guid id)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);
            ReadAuthorDto authorDto = _mapper.Map<ReadAuthorDto>(author);

            return authorDto;
        }

        public IEnumerable<ReadAuthorDto> SearchByName(string name)
        {
            var author = _context.Authors.Where(author => author.FullName.ToLower().Contains(name.ToLower())).ToList().OrderBy(author => author.FullName);

            IEnumerable<ReadAuthorDto> authorDto = _mapper.Map<List<ReadAuthorDto>>(author);

            return authorDto;
        }

        public ReadAuthorDto Update(Guid id, UpdateAuthorDto dto)
        {
            Author author = _context.Authors.FirstOrDefault(author => author.Id == id);

            if (author != null)
            {
                _mapper.Map(dto, author);
                _context.SaveChanges();
                ReadAuthorDto authorDto = _mapper.Map<ReadAuthorDto>(author);

                return authorDto;
            }

            return null;

        }
    }
}