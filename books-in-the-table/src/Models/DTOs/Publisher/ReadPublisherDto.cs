
namespace books_in_the_table.Models.DTOs.Publisher
{
    public class ReadPublisherDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual List<Models.Entities.Book> Books { get; set; }

        public virtual ICollection<Models.Entities.AuthorPublisher> AuthorPublishers { get; set; }

    }
}