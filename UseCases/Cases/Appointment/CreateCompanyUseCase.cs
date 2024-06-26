using Domain.Interfaces;
using Domain.Models.Appointment;
using UseCases.DTOs.Requests;
using UseCases.DTOs.Responses;

namespace UseCases.Cases.Appointment;

public class CreateCompanyUseCase
{
    private readonly IRepository<Company> _companyRepository;
    private readonly ICustomMapper<Company, CompanyCreateRequest> _companyRequestMapper;
    private readonly ICustomMapper<Company, CompanyCreateResponse> _companyResponseMapper;

    public CreateCompanyUseCase(
        IRepository<Company> companyRepository,
        ICustomMapper<Company, CompanyCreateRequest> companyRequestMapper,
        ICustomMapper<Company, CompanyCreateResponse> companyResponseMapper
        )
    {
        _companyRepository = companyRepository;
        _companyRequestMapper = companyRequestMapper;
        _companyResponseMapper = companyResponseMapper;
    }

    public async Task<CompanyCreateResponse> Run(CompanyCreateRequest request)
    {
        Company company = _companyRequestMapper.MapToEntity(request);
        await _companyRepository.AddAsync(company);
        await _companyRepository.SaveChangesAsync();
        CompanyCreateResponse companyResponse = _companyResponseMapper.MapToDto(company); 
        return companyResponse;
    }
}