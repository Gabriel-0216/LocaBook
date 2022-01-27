using Infra.Data;
using Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Users;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public Task<User?> Login(User login)
    {
        var user = _context.Users
            .Where(p => p.Email == login.Email && p.PasswordHash == login.PasswordHash)
            .FirstOrDefaultAsync();
        return user;
    }
    public async Task<User?> Registration(User register)
    {
        _context.Users.Add(register);
        await _context.SaveChangesAsync();
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Id == register.Id);
    }
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.Email == email);
    }
    public async Task<User?> GetUserByUserName(string userName)
    {
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => p.UserName == userName);
    }

    public async Task<bool> CheckUniquesUser(string email, string username, string cellphone)
    {
        if (await _context.Users.FirstOrDefaultAsync(p => p.Email == email) is not null) return false;
        if (await _context.Users.FirstOrDefaultAsync(p => p.UserName == username) is not null) return false;
        return await _context.Users.FirstOrDefaultAsync(p => p.Cellphone == cellphone) is null;
    }
}