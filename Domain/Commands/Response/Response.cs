namespace Domain.Commands.Response
{
    public class Response
    {
        protected Response()
        {
            Errors = new List<string>();
        }

        public void SetSuccess()
        {
            Success = true;
        }
        public void SetInternalError()
        {
            Success = false;
            Errors.Add("Internal server error");
        }
        public int Id { get; set; }
        public bool Success { get; set; } = false;
        public List<string> Errors { get; set; }
    }
}
