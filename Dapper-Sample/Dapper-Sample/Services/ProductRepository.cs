using System.Data.SqlClient;
using Dapper;
using Dapper_Sample.Interfaces;
using Dapper_Sample.Models;

namespace Dapper_Sample.Services;

public class ProductRepository : IProductRepository
{
    private readonly ICommandText _commandText;
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration, ICommandText commandText)
    {
        _commandText = commandText;
        _connectionString = configuration.GetConnectionString("Dapper");
    }
    
    public List<Product> GetList()
    {
        var query = ExecuteCommand(_connectionString, conn => conn.Query<Product>(_commandText.GetList)).ToList();
        
        return query;
    }

    public Product Load(int id)
    {
        var query = ExecuteCommand(_connectionString, conn => conn.Query<Product>(_commandText.Load, new{@Id=id})).SingleOrDefault();

        return query;
    }

    public void Add(Product instance)
    {
        ExecuteCommand(_connectionString,
            conn => conn.Query(_commandText.Add,
                new { instance.Name, instance.Cost, instance.CreateDate }));
    }

    public void Update(Product instance)
    {
        ExecuteCommand(_connectionString,
            conn => conn.Query(_commandText.Update,
                new { instance.Name, instance.Cost, instance.CreateDate, instance.Id }));
    }

    public void Delete(int id)
    {
        ExecuteCommand(_connectionString,
            conn => conn.Query(_commandText.Delete,
                new { @Id = id }));
    }

    #region Helper

    private T ExecuteCommand<T>(string connection, Func<SqlConnection, T> task)
    {
        using (var conn = new SqlConnection(connection))
        {
            conn.Open();
            return task(conn);
        }
    }

    #endregion
}