using System.Net;
using Microsoft.AspNetCore.Mvc;
using UserAuthentication.DTO_s;
using UserAuthentication.Models;
using UserAuthentication.Services.Interfaces;
using UserAuthentication.Utilities.Exceptions;

namespace UserAuthentication.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController(IUserService _userService)
{
    [HttpGet]
    public async Task<List<User>> GetAllUsers()
    {
        
        return await _userService.GetAllUsers();
    }

    [HttpPost]
    public async Task<User> CreateUser(UserDTO user)
    {
        return await _userService.CreateUser(user);
    }
}