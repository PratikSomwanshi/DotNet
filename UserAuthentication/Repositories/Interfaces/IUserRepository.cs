using UserAuthentication.DTO_s;
using UserAuthentication.Models;

namespace UserAuthentication.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsers();
    
    public Task<User> GetUserByUserName(UserDTO user);
    
    public Task<User> CreateUser(UserDTO user);

    
}