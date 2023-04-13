using AutoMapper;
using books_in_the_table.Data;
using books_in_the_table.Interfaces;
using books_in_the_table.Models.DTOs.Book;
using books_in_the_table.Models.Entities;

namespace books_in_the_table.Domain
{
    public class BookDomain : IBook
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookDomain(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ReadBookDto Add(AddBookDto dto)
        {
            Book bookModel = _mapper.Map<Book>(dto);
            _context.Books.Add(bookModel);
            _context.SaveChanges();
            ReadBookDto bookDto = _mapper.Map<ReadBookDto>(bookModel);

            return bookDto;
        }

        public bool Delete(Guid id)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);

            if (book != null)
            {
                _context.Remove(book);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<ReadBookDto> SearchAll()
        {
            var book = _context.Books.ToList();
            IEnumerable<ReadBookDto> bookDto = _mapper.Map<List<ReadBookDto>>(book);

            return bookDto;
        }

        public ReadBookDto SearchById(Guid id)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);
            ReadBookDto bookDto = _mapper.Map<ReadBookDto>(book);

            return bookDto;
        }

        public ReadBookDto Update(Guid id, UpdateBookDto dto)
        {
            Book book = _context.Books.FirstOrDefault(book => book.Id == id);

            if (book != null)
            {
                _mapper.Map(dto, book);
                _context.SaveChanges();
                ReadBookDto bookDto = _mapper.Map<ReadBookDto>(book);

                return bookDto;
            }

            return null;
        }
    }
}