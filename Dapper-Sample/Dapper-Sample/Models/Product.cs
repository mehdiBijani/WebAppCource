using System.Diagnostics.CodeAnalysis;

namespace Dapper_Sample.Models;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public double Cost { get; set; }
    
    [AllowNull]
    public DateTime? CreateDate { get; set; }
}