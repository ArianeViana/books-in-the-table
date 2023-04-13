using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_in_the_table.Models.DTOs.Publisher;

namespace books_in_the_table.Interfaces
{
    public interface IPublisher : IBase<AddPublisherDto, ReadPublisherDto>, IUpdate<UpdatePublisherDto, ReadPublisherDto>
    {

    }
}