using System.Linq.Expressions;
using Domain.Interfaces;

namespace Domain.Generics;

public class FindSpecification<T> : IFindSpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; set; }
    public Expression<Func<T, object>> OrderBy { get; set; }
    
    public List<string> Include { get; set; }
    public string IncludeProperties { get; set; }
    public Expression<Func<T, T>> Selector { get; set; }
}