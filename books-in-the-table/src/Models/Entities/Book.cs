
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace books_in_the_table.Models.Entities
{
    [Table("book")]
    public class Book
    {
        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("isbn13")]
        public string Isbn13 { get; set; }

        [Required]
        [Column("isbn10")]
        public string Isbn10 { get; set; }

        [Required]
        [Column("release_year")]
        public string ReleaseYear { get; set; }

        [Required]
        [Column("number_pages")]
        public int NumberPages { get; set; }

        [Column("language")]
        public string? Language { get; set; }

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