using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace books_in_the_table.Models.Entities
{
    [Table("author")]
    public class Author
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("nationality")]
        public string? Nationality { get; set; }

        [JsonIgnore]
        public virtual List<Book> Books { get; set; }

        [JsonIgnore]
        public virtual ICollection<AuthorPublisher> AuthorPublishers { get; set; }




    }
}