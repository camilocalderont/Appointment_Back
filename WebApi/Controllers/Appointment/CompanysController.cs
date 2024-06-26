using Microsoft.AspNetCore.Mvc;
using UseCases.Cases.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace Appointment_Back.Controllers.Appointment;

[ApiController]
[Route("api/v1/[controller]")]

public class CompanysController : ControllerBase
{

    private readonly CreateCompanyUseCase _createCompanyUseCase;
    public CompanysController(
        CreateCompanyUseCase createCompanyUseCase
        )
    {
        _createCompanyUseCase = createCompanyUseCase;
    }
    
    [HttpPost]
    public async Task<ActionResult<CompanyCreateResponse>> create(CompanyCreateRequest company)
    {
        try
        {
            var response = await _createCompanyUseCase.Run(company);
            return Ok(new
            {
                Success = true,
                Message = "Company created successfully!",
                Data = response
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                Success = false,
                Message = $"Error creating the company: {ex.Message}"

            });
        }
    }

}