namespace UserAuthentication.DTO_s;

public class UserLoginDTO(string username, string token)
{
    public string UserName { get; set; } = username;
    public string Token { get; set; } = token;
}