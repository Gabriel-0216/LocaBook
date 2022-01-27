namespace Domain.Commands.Response
{
    public class CreateClientResponse : Response
    {
        public void SetSuccess(int id, string firstName, string lastName, string email, string cellphone,
            DateTime createDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Cellphone = cellphone;
            CreateDate = createDate;
            Success = true;
        }
        private string FirstName { get; set; } = string.Empty;
        private string LastName { get; set; } = string.Empty;
        private string Email { get; set; } = string.Empty;
        private string Cellphone { get; set; } = string.Empty;
        private DateTime CreateDate { get; set; }
    }
}
