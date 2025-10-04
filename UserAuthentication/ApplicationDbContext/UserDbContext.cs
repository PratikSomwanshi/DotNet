using Microsoft.EntityFrameworkCore;
using UserAuthentication.Models;

namespace UserAuthentication.ApplicationDbContext;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options): base(options){}
    
    public DbSet<User>  Users { get; set; }
}