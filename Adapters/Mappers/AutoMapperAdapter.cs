using Domain.Interfaces;

namespace Adapters.Mappers;
using AutoMapper;

public class AutoMapperAdapter<TEntity, TDto> : ICustomMapper<TEntity, TDto>
{
    private readonly IMapper _mapper;

    public AutoMapperAdapter(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDto MapToDto(TEntity entity)
    {
        return _mapper.Map<TDto>(entity);
    }

    public TEntity MapToEntity(TDto dto)
    {
        return _mapper.Map<TEntity>(dto);
    }
}