using Domain.Queries.Query;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Queries.Handlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<Client>>
    {
        private readonly IClientRepository _repo;

        public GetAllClientsHandler(IClientRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get(request.IncludeLoans, request.ActiveLoans, request.Skip, request.Take);
        }
    }
}
