namespace Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(IFindSpecification<TEntity> spec = null);
    Task<TEntity> GetAsyncNoTracking(IFindSpecification<TEntity> spec = null);
    Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> spec = null);
    Task<IEnumerable<TEntity>> GetAllPagedAsync(IPagedSpecification<TEntity> spec = null);
    void Update(TEntity entity);
    Task UpdateAsync(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entities);
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void SaveChanges();
    Task SaveChangesAsync();
    //... otros métodos del repositorio como Add, Update, Delete, etc.
}