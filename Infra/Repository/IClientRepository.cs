using Infra.Models;

namespace Infra.Repository;

public interface IClientRepository : IGenericRepository<Client>
{
    Task<IEnumerable<Client>> Get(bool includeLoans, bool onlyActiveLoans, int skip, int take);
}