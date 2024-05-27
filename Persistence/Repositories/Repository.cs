using System.Linq.Expressions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Repositories;

/// <summary>
///  Refactorizacion de codigo para BaseRepository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;

    public Repository(DbContext context)
    {
        _context = context;
    }
    #region PublicMethods

    public async Task<TEntity> GetAsync(IFindSpecification<TEntity> spec = null)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsTracking();

        if (spec != null)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            
            if (!string.IsNullOrEmpty(spec.IncludeProperties))
            {
                spec.IncludeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(property =>
                {
                    query = query.Include(property);
                });
            }
            
            if (spec.Include != null)
            {
                foreach (var includeProperty in spec.Include)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (spec.OrderBy != null)
            {
                if (spec.Selector != null)
                {
                    return await query.OrderBy(spec.OrderBy).Select(spec.Selector).FirstOrDefaultAsync();
                }

                return await query.OrderBy(spec.OrderBy).FirstOrDefaultAsync();
            }

            if (spec.Selector != null)
            {
                return await query.Select(spec.Selector).FirstOrDefaultAsync();
            }
            
            return await query.FirstOrDefaultAsync();   
        }
        return await query.FirstOrDefaultAsync();
    }

    public async Task<TEntity> GetAsyncNoTracking(IFindSpecification<TEntity> spec = null)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();

        if (spec != null)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            
            if (!string.IsNullOrEmpty(spec.IncludeProperties))
            {
                spec.IncludeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(property =>
                {
                    query = query.Include(property);
                });
            }
            
            if (spec.Include != null)
            {
                foreach (var includeProperty in spec.Include)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (spec.OrderBy != null)
            {
                if (spec.Selector != null)
                {
                    return await query.OrderBy(spec.OrderBy).Select(spec.Selector).FirstOrDefaultAsync();
                }

                return await query.OrderBy(spec.OrderBy).FirstOrDefaultAsync();
            }

            if (spec.Selector != null)
            {
                return await query.Select(spec.Selector).FirstOrDefaultAsync();
            }
            
            return await query.AsNoTracking().FirstOrDefaultAsync();   
        }
        return await query.AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity> spec = null)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (spec != null)
        {
            query = BuildQuery(spec.Criteria, spec.OrderBy, spec.Include, spec.IncludeProperties);
        }

        return await query.ToListAsync();
    }
    
    public async Task<IEnumerable<TEntity>> GetAllPagedAsync(IPagedSpecification<TEntity> spec = null)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();

        if (spec != null)
        {
            query = BuildQuery(spec.Criteria, spec.OrderBy, spec.Include, spec.IncludeProperties).Skip(spec.Skip).Take(spec.Take);
        }
        return await query.ToListAsync();
    }
    
    public void Update(TEntity entity)
    {
        ValidateEntity(entity);
        _context.Set<TEntity>().Update(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        ValidateEntity(entity);
        _context.Set<TEntity>().Update(entity);
        
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        ValidateRangeEntities(entities);
        _context.Set<TEntity>().UpdateRange(entities);
    }

    public void Add(TEntity entity)
    {
        ValidateEntity(entity);
        _context.Set<TEntity>().Add(entity);
        
    }

    public async Task AddAsync(TEntity entity)
    {
        ValidateEntity(entity);
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    #endregion
    
    #region PrivateMethods

    private IQueryable<TEntity> BuildQuery(
        Expression<Func<TEntity, bool>>? filter = null,
        Expression<Func<TEntity, object>>? OrderBy = null,
        List<string> include = null,
        string includeProperties = "")
    {
        var query = _context.Set<TEntity>().AsNoTracking();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (include != null)
        {
            foreach (var includeProperty in include)
            {
                query = query.Include(includeProperty);
            }
        }

       
        if (!string.IsNullOrEmpty(includeProperties))
        {
            includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(property =>
            {
                query = query.Include(property);
            });
        }


        if (OrderBy != null)
        {
            query = query.OrderBy(OrderBy);
        }

        return query;
    }
    
    private static void ValidateEntity(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "El objeto entidad no puede ser nulo");
        }
    }
    
    private static void ValidateRangeEntities(IEnumerable<TEntity> entities)
    {
        if (!entities?.Any() ?? true)
        {
            throw new ArgumentNullException(nameof(entities), "no se envió una lista de entidades a insertar");
        }
    }    
    #endregion
    
}
