namespace Domain.Commands.Response;

public class UpdateLoanResponse : Response
{
    public void SetSuccess(int id, bool newStatus)
    {
        base.SetSuccess();
        Id = id;
        NewStatus = newStatus;
    }
    public bool NewStatus { get; set; }
}