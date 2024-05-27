namespace Domain.Interfaces;

public interface ICustomMapper<TEntity, TDto>
{
    TDto MapToDto(TEntity entity);
    TEntity MapToEntity(TDto dto);
}