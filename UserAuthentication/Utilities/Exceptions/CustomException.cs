using System.Net;

namespace UserAuthentication.Utilities.Exceptions;

public class CustomException: Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;

    public CustomException(HttpStatusCode statusCode, string message):base(message)
    {
        this.StatusCode = statusCode;
        this.Message = message;
    }
}