
namespace books_in_the_table.Models.DTOs.AuthorPublisher
{
    public class ReadAuthorPublisherDto
    {
        public Guid Id { get; set; }
        public virtual Models.Entities.Author Author { get; set; }
        public virtual Models.Entities.Publisher Publisher { get; set; }
    }
}