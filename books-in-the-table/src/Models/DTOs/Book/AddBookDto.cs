
namespace books_in_the_table.Models.DTOs.Book
{
    public class AddBookDto
    {
        public string Title { get; set; }
        public string Isbn13 { get; set; }
        public string Isbn10 { get; set; }
        public string ReleaseYear { get; set; }
        public int NumberPages { get; set; }
        public string? Language { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
    }
}