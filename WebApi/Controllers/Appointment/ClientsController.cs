using Microsoft.AspNetCore.Mvc;
using UseCases.Cases.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace Appointment_Back.Controllers.Appointment;

[ApiController]
[Route("api/v1/[controller]")]

public class ClientsController : ControllerBase
{
    
    private readonly CreateClientUseCase _createClientUseCase;
    private readonly SearchClientByEmailUseCase _searchClientByEmailUseCase;
    private readonly SearchClientByPhoneUseCase _searchClientByPhoneUseCase;
    public ClientsController(
        CreateClientUseCase createClientUseCase,
        SearchClientByEmailUseCase searchClientByEmailUseCase,
        SearchClientByPhoneUseCase searchClientByPhoneUseCase
        )
    {
        _createClientUseCase = createClientUseCase;
        _searchClientByEmailUseCase = searchClientByEmailUseCase;
        _searchClientByPhoneUseCase = searchClientByPhoneUseCase;
    }

    /// <summary>
    /// HU-2.1: Diseñar y desarrollar el endpoint para la creación de clientes
    /// </summary>
    /// <param name="client"></param>
    /// <returns>ClientCreateResponse</returns>
    [HttpPost]
    public async Task<ActionResult<ClientCreateResponse>> create(ClientCreateRequest client)
    {
        var response = await _createClientUseCase.Run(client);
        return Ok(response);
    }
    
    /// <summary>
    /// HU-2.2: Diseñar y desarrollar el endpoint para la consulta de clientes
    /// De esta manera se puede buscar un cliente por email, con petición get
    /// El parametro por url
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet("email/{email}")]
    public async Task<ActionResult<ClientCreateResponse>> search(string email)
    {
        var request = new SearchClientByEmailRequest
        {
            VcEmail = email
        };
        var response = await _searchClientByEmailUseCase.Run(request);
        return Ok(response);
    }
    
    
    /// <summary>
    /// HU-2.2: Diseñar y desarrollar el endpoint para la consulta de clientes
    /// De esta manera se puede buscar un cliente por email, con petición get
    /// El parametro por url
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    [HttpGet("phone/{phone}")]
    public async Task<ActionResult<ClientCreateResponse>> searchByPhone(string phone)
    {
        var request = new SearchClientByPhoneRequest
        {
            VcPhone = phone
        };
        var response = await _searchClientByPhoneUseCase.Run(request);
        return Ok(response);
    }
    
}