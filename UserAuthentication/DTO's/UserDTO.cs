namespace UserAuthentication.DTO_s;

public class UserDTO
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = "User";
}