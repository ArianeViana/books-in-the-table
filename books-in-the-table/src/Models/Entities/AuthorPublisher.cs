
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace books_in_the_table.Models.Entities
{
    [Table("author_publisher")]
    public class AuthorPublisher
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("author_id")]
        public Guid AuthorId { get; set; }

        [Column("publisher_id")]
        public Guid PublisherId { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }

        [JsonIgnore]
        public virtual Publisher Publisher { get; set; }
    }
}