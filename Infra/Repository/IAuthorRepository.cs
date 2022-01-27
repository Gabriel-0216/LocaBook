using Infra.Models;

namespace Infra.Repository;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<IEnumerable<Author>> Get(bool includeBook, int skip, int take);
}