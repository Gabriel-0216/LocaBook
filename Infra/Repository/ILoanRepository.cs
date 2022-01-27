using Infra.Models;

namespace Infra.Repository
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetCompletedLoans(bool includeBooks, bool includeClient, int skip, int take);
        Task<IEnumerable<Loan>> GetUnfinishedLoans(bool includeBooks, bool includeClient, int skip, int take);
        Task<IEnumerable<Loan>> GetLateDevolutions(bool includeBooks, bool includeClient);
        Task<IEnumerable<Loan>> Get(bool includeBooks, bool includeClient, int skip, int take);
    }
}
