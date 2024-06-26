namespace Domain.Models.Appointment;

public class Company
{
    public int Id { get; set; }
    public string VcName { get; set; }
    public string? VcDescription { get; set; }
    public string VcPhone { get; set; }
    public string? VcPrincipalAddress { get; set; }
    public string VcPrincipalEmail { get; set; }
    public string? VcLegalRepresentative { get; set; }
    public string? VcLogo { get; set; }

}