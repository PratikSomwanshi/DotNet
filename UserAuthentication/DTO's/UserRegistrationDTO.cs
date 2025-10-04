namespace UserAuthentication.DTO_s;

public class UserRegistrationDTO(string username)
{
    public string UserName { get; set; } = username;
}