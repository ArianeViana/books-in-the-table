
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace books_in_the_table.Models.Entities
{
    [Table("publisher")]
    public class Publisher
    {

        [Key]
        [Required]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Book> Books { get; set; }

        [JsonIgnore]
        public virtual ICollection<AuthorPublisher> AuthorPublishers { get; set; }


    }
}