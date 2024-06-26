namespace UseCases.DTOs.Requests;
#pragma warning disable CS8618 // Deshabilitar warning CS8618
public class CompanyCreateRequest
{
    public string VcName { get; set; }
    public string? VcDescription { get; set; }
    public string VcPhone { get; set; }
    public string? VcPrincipalAddress { get; set; }
    public string VcPrincipalEmail { get; set; }
    public string? VcLegalRepresentative { get; set; }
    public string? VcLogo { get; set; }
}
#pragma warning restore CS8618 // Habilitar warning CS8618