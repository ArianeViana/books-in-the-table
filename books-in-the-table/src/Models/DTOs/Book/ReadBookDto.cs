
namespace books_in_the_table.Models.DTOs.Book
{
    public class ReadBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Isbn13 { get; set; }
        public string Isbn10 { get; set; }
        public string ReleaseYear { get; set; }
        public int NumberPages { get; set; }
        public string? Language { get; set; }
        //são necessários?
        public Models.Entities.Author Author { get; set; }
        public Models.Entities.Publisher Publisher { get; set; }
    }
}