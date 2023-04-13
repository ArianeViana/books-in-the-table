using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_in_the_table.Models.DTOs.AuthorPublisher
{
    public class UpdateAuthorPublisherDto
    {
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
    }
}