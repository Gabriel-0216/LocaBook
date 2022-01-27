using Domain.Commands.Requests;
using Domain.Commands.Response;
using Infra.Models;
using Infra.Repository;
using MediatR;

namespace Domain.Commands.Handlers;

public class UpdateClientHandler : IRequestHandler<UpdateClientRequest, UpdateClientResponse>
{
    private readonly IClientRepository _repo;

    public UpdateClientHandler(IClientRepository repo)
    {
        _repo = repo;
    }

    public async Task<UpdateClientResponse> Handle(UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var response = new UpdateClientResponse();
        if(string.IsNullOrWhiteSpace(request.Cellphone)) response.Errors.Add("The cellphone can't be empty or null");
        if(string.IsNullOrWhiteSpace(request.Email)) response.Errors.Add("The Email can't be empty or null");
        if(string.IsNullOrWhiteSpace(request.FirstName)) response.Errors.Add("The First Name can't be empty or null");
        if(string.IsNullOrWhiteSpace(request.LastName)) response.Errors.Add("The Last Name can't be empty or null");

        if (response.Errors.Count > 0) return response;
        var exists = await _repo.Get(request.Id);
        if (exists == null)
        {
            response.Errors.Add("This client don't exists");
            return response;
        }
        exists.Cellphone = request.Cellphone;
        exists.Email = request.Email;
        exists.FirstName = request.FirstName;
        exists.LastName = request.LastName;
        
        var updated = await _repo.Update(exists);

        if (updated == null)
        {
            response.SetInternalError();
            return response;
        }
        
        response.SetSuccess(updated.Id, updated.FirstName, updated.LastName, updated.Email, updated.Cellphone);
        return response;




    }
}