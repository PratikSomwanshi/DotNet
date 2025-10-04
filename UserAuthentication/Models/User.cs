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
    
}