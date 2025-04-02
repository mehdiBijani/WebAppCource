using Dapper_Sample.Interfaces;

namespace Dapper_Sample.Services;

public class CommandText : ICommandText
{
    public string GetList => "Select * From Product";
    public string Load => "Select * From Product Where Id =@Id";
    public string Add => "Insert Into Product (Name, Cost, CreateDate) Values (@Name, @Cost, @CreateDate)";
    public string Update => "Update Product Set Name = @Name, Cost = @Cost, CreateDate = @CreateDate Where Id = @Id";
    public string Delete => "Delete From Product Where Id = @Id";
}