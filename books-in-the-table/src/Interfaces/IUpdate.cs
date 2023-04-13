
namespace books_in_the_table.Interfaces
{
    public interface IUpdate<in T, out A>
    {
        A Update(Guid id, T obj);
    }
}