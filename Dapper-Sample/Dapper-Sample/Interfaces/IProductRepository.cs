using Dapper_Sample.Models;

namespace Dapper_Sample.Interfaces;

public interface IProductRepository
{
    List<Product> GetList();
    Product Load(int id);
    void Add(Product instance);
    void Update(Product instance);
    void Delete(int id);
}