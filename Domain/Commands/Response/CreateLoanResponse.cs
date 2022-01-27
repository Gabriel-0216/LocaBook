namespace Domain.Commands.Response
{
    public class CreateLoanResponse : Response
    {
        public void SetSuccess(int loanId, int clientId, DateTime startDate, DateTime devolutionDate)
        {
            base.SetSuccess();
            Id = loanId;
            ClientId = clientId;
            Start_Date = startDate;
            Devolution_Date = devolutionDate;
        }
        private int ClientId { get; set; }
        private DateTime Start_Date { get; set; }
        private DateTime Devolution_Date { get; set; }

    }
}
