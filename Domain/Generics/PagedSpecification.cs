using Domain.Interfaces;

namespace Domain.Generics;

public class PagedSpecification<T> : GenericSpecification<T>, IPagedSpecification<T>
{
    public int Skip { get; set; }
    public int Take { get; set; }
}
