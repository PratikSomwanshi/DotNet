using System.Net;
using UserAuthentication.DTO_s;
using UserAuthentication.Models;
using UserAuthentication.Repositories.Interfaces;
using UserAuthentication.Services.Interfaces;
using UserAuthentication.Utilities.Exceptions;

namespace UserAuthentication.Services;

public class UserService(IUserRepository _userRepository): IUserService
{
    
    public async Task<List<User>> GetAllUsers()
    {
        
        return await _userRepository.GetAllUsers();
    }

    public async Task<User> CreateUser(UserDTO user)
    {
        throw new CustomException(HttpStatusCode.BadRequest, "Testing going good");
        return await _userRepository.CreateUser(user);
    }
}