using Domain.Interfaces;
using Domain.Models.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace UseCases.Cases.Appointment;

public class CreateClientUseCase
{
    private readonly IRepository<Client> _clientRepository;
    private readonly ICustomMapper<Client, ClientCreateRequest> _clientRequestMapper;
    private readonly ICustomMapper<Client, ClientCreateResponse> _clientResponseMapper;

    public CreateClientUseCase(
        IRepository<Client> clientRepository,
        ICustomMapper<Client, ClientCreateRequest> clientRequestMapper,
        ICustomMapper<Client, ClientCreateResponse> clientResponseMapper
        )
    {
        _clientRepository = clientRepository;
        _clientRequestMapper = clientRequestMapper;
        _clientResponseMapper = clientResponseMapper;
    }

    public async Task<ClientCreateResponse> Run(ClientCreateRequest request)
    {
        Client client = _clientRequestMapper.MapToEntity(request);
        await  _clientRepository.AddAsync(client);
        await _clientRepository.SaveChangesAsync();
        ClientCreateResponse clientResponse = _clientResponseMapper.MapToDto(client); 
        return clientResponse;
    }
}