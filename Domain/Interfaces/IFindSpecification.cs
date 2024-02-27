using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IFindSpecification<TEntity> : ISpecification<TEntity>
{
    Expression<Func<TEntity, TEntity>>  Selector { get; }
}