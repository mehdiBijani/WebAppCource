using MehdiShop.Data.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MehdiShop.Components;

public class ProductGroupsComponent : ViewComponent
{
    private IGroupRepository _groupRepository;

    public ProductGroupsComponent(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = _groupRepository.GetGroupForShow();
        
        return View("/Views/Components/ProductGroupsComponent.cshtml", categories);
    }
}