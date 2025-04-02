namespace Dapper_Sample.Interfaces;

public interface ICommandText
{
    string GetList { get; }
    string Load { get; }
    string Add { get; }
    string Update { get; }
    string Delete { get; }
}