using Domain.Queries.Query;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Queries.Handlers
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllAuthorsHandler(IAuthorRepository author)
        {
            _repository = author;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.IncludeBooks, request.Skip, request.Take);
        }
    }
}
