namespace Infra.Models
{
    public class Author : Entity
    {
        public Author()
        {
            Books = new List<Book>();
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public IList<Book> Books { get; set; }

    }
}
