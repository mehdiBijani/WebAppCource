using MehdiShop.Data.IRepositories;
using MehdiShop.Models;

namespace MehdiShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    private MehdiShopContext _context;

    public UserRepository(MehdiShopContext context)
    {
        _context = context;
    }

    public bool IsExistEmail(string email)
    {
        return _context.User.Any(x => x.Email == email);
    }

    public void AddUser(User user)
    {
        _context.Add(user);
        _context.SaveChanges();
    }

    public User GetUserForLogin(string email, string password)
    {
        return _context.User.SingleOrDefault(x => x.Email == email && x.Password == password);
    }
}