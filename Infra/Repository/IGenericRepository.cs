namespace Infra.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> Get(int id);
        Task<IEnumerable<T>> Get();
        Task<T?> Add(T entity);
        Task<bool> Delete(T entity);
        Task<T?> Update(T entity);
        Task<bool> EntityExists(int id);
    }
}
