using System.ComponentModel.DataAnnotations;

namespace UserAuthentication.Models;

public class User
{
    [Key]
    public Guid Id { get; set; } =  Guid.NewGuid();
    
    [Required]
    [Length(3, 20)]
    public string UserName { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } =  string.Empty;

    public string Roles { get; set; } = "User";

    public override string ToString()
    {
        return $"User {{ Id = {Id}, UserName = {UserName}, Password = {Password} Roles = {Roles} }}";
    }
}