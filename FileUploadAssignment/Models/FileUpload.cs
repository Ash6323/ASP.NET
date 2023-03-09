namespace FileUploadAssignment.Models
{
    public class FileUploadClass
    {
        public IFormFile file { get; set; }
    }
    public class Response
    {
        public Response(int status, string responseMessage) 
        {
            this.statusCode = status;
            this.message = responseMessage;
        }
        public int statusCode { get; set; }
        public string message { get; set; } = String.Empty;
    }
}
