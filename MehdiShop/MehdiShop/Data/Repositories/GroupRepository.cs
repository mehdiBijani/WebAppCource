using MehdiShop.Data.IRepositories;
using MehdiShop.Models;

namespace MehdiShop.Data.Repositories;

public class GroupRepository : IGroupRepository
{
private MehdiShopContext _context;

public GroupRepository(MehdiShopContext context)
{
    _context = context;
}
public IEnumerable<Category> GetAllCategories()
{
    return _context.Categories;
}

public IEnumerable<ShowGroupViewModel> GetGroupForShow()
{
    return _context.Categories
        .Select(x => new ShowGroupViewModel
        {
            GroupId = x.Id,
            Name = x.Name,
            ProductCount = x.CategoryToProducts.Count(c => c.CategoryId == x.Id)
        }).ToList();
}
}