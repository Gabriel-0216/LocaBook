using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Commands.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientRequest, CreateClientResponse>
    {
        private readonly IClientRepository _repo;
        public CreateClientHandler(IClientRepository repo)
        {
            _repo = repo;
        }
        public async Task<CreateClientResponse> Handle(CreateClientRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateClientResponse();
            if (string.IsNullOrWhiteSpace(request.Email)) response.Errors.Add("The email cannot be null");
            if (string.IsNullOrWhiteSpace(request.FirstName)) response.Errors.Add("The first name cannot be null");
            if (string.IsNullOrWhiteSpace(request.LastName)) response.Errors.Add("The last name cannot be null");
            if (string.IsNullOrWhiteSpace(request.Cellphone)) response.Errors.Add("The Cellphone cannot be null");

            if (response.Errors.Count > 0) return response;

            var inserted = await _repo.Add(new Client(0, request.FirstName, request.LastName, 
                                                                    request.Email, request.Cellphone, DateTime.Now));
            
            if(inserted != null)
            {
                response.SetSuccess(inserted.Id, inserted.FirstName, inserted.LastName, inserted.Email, inserted.Cellphone, inserted.CreateDate);
                return response;
            }
            response.SetInternalError();
            return response;
        }
    }
}
