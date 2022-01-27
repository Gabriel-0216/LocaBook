using Infra.Models;

namespace Infra.Repository.Users;

public interface IUserRepository
{
    Task<User?> Login(User login);
    Task<User?> Registration(User register);
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserByUserName(string userName);

    Task<bool> CheckUniquesUser(string email, string username, string cellphone);
}