using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using UserAuthentication.DTO_s;
using UserAuthentication.Models;
using UserAuthentication.Repositories.Interfaces;
using UserAuthentication.Services.Interfaces;
using UserAuthentication.Utilities.Exceptions;

namespace UserAuthentication.Services;

public class UserService(
    IUserRepository _userRepository,
    IConfiguration _config
    ): IUserService
{
    
    public async Task<List<User>> GetAllUsers()
    {
        
        return await _userRepository.GetAllUsers();
    }

    public async Task<User> CreateUser(UserDTO user)
    {
        // throw new CustomException(HttpStatusCode.BadRequest, "Testing going good");

        string passwordHashed = new PasswordHasher<object>().HashPassword(user, user.Password);
        
        user.Password = passwordHashed;

        return await _userRepository.CreateUser(user);
    }

    public async Task<UserLoginDTO> Login(UserDTO user)
    {

        User existingUser = await _userRepository.GetUserByUserName(user);
        
        Console.WriteLine(existingUser);
        
        PasswordVerificationResult hasher = new PasswordHasher<object>().VerifyHashedPassword(
            user,
            existingUser.Password,
            user.Password
        );
        
        
        
        
        if (hasher == PasswordVerificationResult.Failed)
        {
            throw new CustomException(HttpStatusCode.BadRequest, "Invalid username or password");
        }
        //
        string token = GenerateJWTTocken(user);
        
        

        return new UserLoginDTO(
            user.UserName,token);
    }
    
    private string GenerateJWTTocken(UserDTO user)
    {
        SymmetricSecurityKey _key = new(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
        );

        SigningCredentials creds = new(
            _key,
            SecurityAlgorithms.HmacSha256
        );

        Claim[] claims = new[]
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };

        JwtSecurityToken token = new(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds
        );
        
        return new  JwtSecurityTokenHandler().WriteToken(token);

    }
}