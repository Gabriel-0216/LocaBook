using Domain.Commands.Response;
using MediatR;
namespace Domain.Commands.Requests;
public class UpdateClientRequest : IRequest<UpdateClientResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cellphone { get; set; } = string.Empty;
}