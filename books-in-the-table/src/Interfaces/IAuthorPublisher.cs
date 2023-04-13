using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_in_the_table.Models.DTOs.AuthorPublisher;

namespace books_in_the_table.Interfaces
{
    public interface IAuthorPublisher : IBase<AddAuthorPublisherDto, ReadAuthorPublisherDto>, IUpdate<UpdateAuthorPublisherDto, ReadAuthorPublisherDto>
    {

    }
}