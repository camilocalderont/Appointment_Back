using System.Linq.Expressions;

namespace Domain.Interfaces;

/// <summary>
/// Define de manera abstracta cómo consultar la fuente de datos (BD) para obtener los datos de una entidad
/// Intenta desacoplar dependencias de EF en capa de Aplicacion
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface ISpecification<TEntity>
{
    Expression<Func<TEntity, bool>> Criteria { get; } 
    Expression<Func<TEntity, object>> OrderBy { get; }
    List<string> Include { get; set; } // Cambiado a una lista de cadenas
    string IncludeProperties { get; } 
}