using MehdiShop.Models;

namespace MehdiShop.Data.IRepositories;

public interface IUserRepository
{
    bool IsExistEmail(string email);
    void AddUser(User user);
}