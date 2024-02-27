namespace Domain.Interfaces;

public interface IPagedSpecification<TEntity> : ISpecification<TEntity>
{
    int Take { get; }
    int Skip { get; }
}