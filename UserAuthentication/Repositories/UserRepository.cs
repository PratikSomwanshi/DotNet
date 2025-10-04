
using System.Net;
using Microsoft.EntityFrameworkCore;
using UserAuthentication.ApplicationDbContext;
using UserAuthentication.DTO_s;
using UserAuthentication.Models;
using UserAuthentication.Repositories.Interfaces;
using UserAuthentication.Utilities.Exceptions;

namespace UserAuthentication.Repositories;

public class UserRepository(
    IConfiguration _config,
    UserDbContext _context
    ): IUserRepository
{
    
    
    
    public async Task<List<User>> GetAllUsers()
    {
        // throw new CustomException(HttpStatusCode.BadRequest, "Testing going good");
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateUser(UserDTO user)
    {
        User newUser = new()
        {
            UserName = user.UserName,
            Password = user.Password,
        };
        
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        
        return newUser;
    }

    public async Task<User> GetUserByUserName(UserDTO user)
    {
        User existingUser = await _context.Users.FirstOrDefaultAsync(ele => ele.UserName == user.UserName);

        if (existingUser is null)
        {
            throw new CustomException(
                HttpStatusCode.NotFound
                ,"User not found");
        }

        return existingUser;
    }

    
    
    
}