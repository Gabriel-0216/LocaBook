namespace Domain.Commands.Response;

public class UpdateBookResponse : Response
{
    public void SetSuccess(int id, string title, string resume, DateTime createDate, int authorId)
    {
        base.SetSuccess();
        Id = id;
        Title = title;
        Resume = resume;
        CreateDate = createDate;
        AuthorId = authorId;
    }
    public string Title { get; set; } = string.Empty;
    public string Resume { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public int AuthorId { get; set; }
}