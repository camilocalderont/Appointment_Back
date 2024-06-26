using AutoMapper;
using Domain.Models.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace Adapters.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Client, ClientCreateRequest>().ReverseMap();
        CreateMap<Client, ClientCreateResponse>().ReverseMap();
        // Agrega aquí los demás perfiles de mapeo necesarios
    }
}