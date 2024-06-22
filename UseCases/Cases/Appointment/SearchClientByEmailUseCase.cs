using Domain.Generics;
using Domain.Interfaces;
using Domain.Models.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace UseCases.Cases.Appointment;

public class SearchClientByEmailUseCase
{
    private readonly IRepository<Client> _clientRepository;
    private readonly ICustomMapper<Client, ClientCreateRequest> _clientRequestMapper;
    private readonly ICustomMapper<Client, ClientCreateResponse> _clientResponseMapper;

    public SearchClientByEmailUseCase(
        IRepository<Client> clientRepository,
        ICustomMapper<Client, ClientCreateRequest> clientRequestMapper,
        ICustomMapper<Client, ClientCreateResponse> clientResponseMapper
        )
    {
        _clientRepository = clientRepository;
        _clientRequestMapper = clientRequestMapper;
        _clientResponseMapper = clientResponseMapper;
    }

    public async Task<ClientCreateResponse> Run(SearchClientByEmailRequest request)
    {
        //Patron Specification
        var specSearchClientByEmail = new FindSpecification<Client>
        {
            Criteria = s => s.VcEmail == request.VcEmail
        };
        var resultados = await _clientRepository.GetAsync(specSearchClientByEmail);
        if (resultados != null)
        {
            return _clientResponseMapper.MapToDto(resultados);
        }
        return null;
    }
}