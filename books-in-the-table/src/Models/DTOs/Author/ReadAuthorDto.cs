
namespace books_in_the_table.Models.DTOs.Author
{
    public class ReadAuthorDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string? Nationality { get; set; }

        public List<Models.Entities.Book> Books { get; set; }

        public virtual ICollection<Models.Entities.AuthorPublisher> AuthorPublishers { get; set; }

    }
}