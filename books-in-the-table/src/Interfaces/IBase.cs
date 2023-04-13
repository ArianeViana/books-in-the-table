
namespace books_in_the_table.Interfaces
{
    public interface IBase<in T, out A>
    {
        A Add(T obj);
        A SearchById(Guid id);
        IEnumerable<A> SearchAll();
        bool Delete(Guid id);
    }
}