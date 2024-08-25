using MehdiShop.Models;

namespace MehdiShop.Data.IRepositories;

public interface IGroupRepository
{
    IEnumerable<Category> GetAllCategories();
    
    IEnumerable<ShowGroupViewModel> GetGroupForShow();
}