namespace Infra.Models
{
    public class Client : Entity
    {
        public Client()
        {
            Loans = new List<Loan>();
        }
        public Client(int id, string firstName, string lastName, string email, string cellPhone, DateTime createDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Cellphone = cellPhone;
            CreateDate = createDate;
            Loans = new List<Loan>();
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cellphone { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public IList<Loan> Loans { get; set; }

    }
}
