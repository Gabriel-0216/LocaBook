namespace Infra.Models
{
    public class Book : Entity
    {
        public Book() => Loans = new List<Loan>();
        public Book(int id, string title, string resume, DateTime createDate, int authorId)
        {
            Id = id;
            Title = title;
            Resume = resume;
            CreateDate = createDate;
            AuthorId = authorId;
            Loans = new List<Loan>();
        }
        public string Title { get; set; } = string.Empty;
        public string Resume { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public IList<Loan> Loans { get; set; }
    }
}
