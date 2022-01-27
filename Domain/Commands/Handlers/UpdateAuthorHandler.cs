using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Commands.Handlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorRequest, UpdateAuthorResponse>
    {
        private readonly IAuthorRepository _repository;

        public UpdateAuthorHandler(IAuthorRepository author)
        {
            _repository = author;
        }
        public async Task<UpdateAuthorResponse> Handle(UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            var updateResponse = new UpdateAuthorResponse();
            if (string.IsNullOrWhiteSpace(request.FirstName)) updateResponse.Errors.Add("The first name cannot be null");
            if (string.IsNullOrWhiteSpace(request.LastName)) updateResponse.Errors.Add("The last name cannot be null");

            if (updateResponse.Errors.Count > 0) return updateResponse;

            var authorExists = await _repository.Get(request.Id);
            if(authorExists == null)
            {
                updateResponse.Errors.Add("This author don't exists!");
                return updateResponse;
            }
            authorExists.FirstName = request.FirstName;
            authorExists.LastName = request.LastName;

            var updated = await _repository.Update(authorExists);
            if(updated == null)
            {
                updateResponse.SetInternalError();
                return updateResponse;
            }
            updateResponse.SetSuccess(updated.Id, updated.FirstName, updated.LastName);
            return updateResponse;
           
        }
    }
}
