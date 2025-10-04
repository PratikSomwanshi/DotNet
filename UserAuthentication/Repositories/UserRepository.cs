using System.Net;
using Microsoft.EntityFrameworkCore;
using UserAuthentication.ApplicationDbContext;
using UserAuthentication.DTO_s;
using UserAuthentication.Models;
using UserAuthentication.Repositories.Interfaces;
using UserAuthentication.Utilities.Exceptions;

namespace UserAuthentication.Repositories;

public class UserRepository: IUserRepository
{
    
    private readonly UserDbContext _context;
    
    public UserRepository(UserDbContext context)
    {
        _context = context;
    }
    
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
}