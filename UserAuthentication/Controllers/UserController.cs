using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAuthentication.DTO_s;
using UserAuthentication.Models;
using UserAuthentication.Services.Interfaces;
using UserAuthentication.Utilities.Responses;

namespace UserAuthentication.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController(IUserService _userService)
{
    [HttpGet]
    public async Task<SuccessResponse<List<User>>> GetAllUsers()
    {
        List<User> users = await _userService.GetAllUsers();

        SuccessResponse<List<User>> res = new(
                "Successfully retrieved all users",
                users
            );

        return res;
    }

    [HttpPost]
    public async Task<SuccessResponse<UserRegistrationDTO>> CreateUser(UserDTO user)
    {
        User u = await _userService.CreateUser(user);

        UserRegistrationDTO reg = new(user.UserName);
        
        SuccessResponse<UserRegistrationDTO> res = new (
            "Successfully created user",
            reg
        );
        
        return res;
    }

    [HttpPost]
    [Route("login")]
    public async Task<UserLoginDTO> Login([FromBody] UserDTO user)
    {
        return await _userService.Login(user);
    }
}