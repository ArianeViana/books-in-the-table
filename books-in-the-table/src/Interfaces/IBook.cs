using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using books_in_the_table.Models.DTOs.Book;

namespace books_in_the_table.Interfaces
{
    public interface IBook : IBase<AddBookDto, ReadBookDto>, IUpdate<UpdateBookDto, ReadBookDto>
    {

    }
}