namespace Infra.Models
{
    public class Loan : Entity
    {
        public Loan() => Books = new List<Book>();
        public Loan(int id, int clientId, DateTime startDate, DateTime devolutionDate, bool isFinished)
        {
            Books = new List<Book>();
            Id = id;
            ClientId = clientId;
            Start_Date = startDate;
            Devolution_Date = devolutionDate;
            IsFinished = isFinished;
        }
        public int ClientId { get; set; }
        public Client? Client { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Devolution_Date { get; set; }
        public bool IsFinished { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}