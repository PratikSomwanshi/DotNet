namespace UserAuthentication.Utilities.Responses;

public class SuccessResponse<T>(bool status, string message, T data)
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public T Data  { get; set; }
    
}