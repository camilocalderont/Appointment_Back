using Microsoft.AspNetCore.Mvc;
using UseCases.Cases.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace Appointment_Back.Controllers.Appointment;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    
    private readonly CreateClientUseCase _createClientUseCase;
    public ClientController(CreateClientUseCase createClientUseCase)
    {
        _createClientUseCase = createClientUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<ClientCreateResponse>> create(ClientCreateRequest client)
    {
        var response = await _createClientUseCase.Run(client);
        return Ok(response);
    }
    
}