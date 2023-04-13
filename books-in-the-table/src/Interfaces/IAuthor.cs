using books_in_the_table.Models.DTOs.Author;

namespace books_in_the_table.Interfaces
{
    public interface IAuthor : IBase<AddAuthorDto, ReadAuthorDto>, IUpdate<UpdateAuthorDto, ReadAuthorDto>
    {
        IEnumerable<ReadAuthorDto> SearchByName(string name);
    }
}