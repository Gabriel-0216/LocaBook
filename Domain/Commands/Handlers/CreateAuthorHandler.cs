using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Commands.Handlers
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorRequest, CreateAuthorResponse>
    {
        private readonly IAuthorRepository _repository;

        public CreateAuthorHandler(IAuthorRepository author)
        {
            _repository = author;
        }
        public async Task<CreateAuthorResponse> Handle(CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateAuthorResponse();
            if (string.IsNullOrWhiteSpace(request.FirstName)) response.Errors.Add("The first name cannot be empty or null");
            if (string.IsNullOrWhiteSpace(request.LastName)) response.Errors.Add("The last name cannot be empty or null");

            if(response.Errors.Count > 0)
            {
                response.Success = false;
                return response;
            }
            var authorCreated = await _repository.Add(new Author()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            });

            if (authorCreated != null)
            {
                response.SetSuccess(id: authorCreated.Id, authorCreated.FirstName, authorCreated.LastName);
                return response;
            }
            response.SetInternalError();
            return response;

        }
    }
}
