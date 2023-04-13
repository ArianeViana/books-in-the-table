
namespace books_in_the_table.Models.DTOs.AuthorPublisher
{
    public class AddAuthorPublisherDto
    {
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }

    }
}