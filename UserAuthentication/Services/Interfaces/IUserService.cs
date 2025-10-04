using UserAuthentication.DTO_s;
using UserAuthentication.Models;

namespace UserAuthentication.Services.Interfaces;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();
    
    public Task<User> CreateUser(UserDTO user);

    public Task<UserLoginDTO> Login(UserDTO user);
}