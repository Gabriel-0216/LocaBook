using Infra.Models;

namespace Infra.Repository;

public interface IBookRepository : IGenericRepository<Book>
{
    Task<IEnumerable<Book>> Get(bool includeAuthor, int skip, int take);
}