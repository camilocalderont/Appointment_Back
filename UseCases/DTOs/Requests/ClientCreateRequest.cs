namespace UseCases.DTOs.Requests;
#pragma warning disable CS8618 // Deshabilitar warning CS8618
public class ClientCreateRequest
{
    public string VcIdentificationNumber {get; set; }
    public string VcPhone {get; set; }
    public string? vcNickName {get; set; }
    public string VcFirstName {get; set; }
    public string? VcSecondName {get; set; }
    public string VcFirstLastName {get; set; }
    public string? VcSecondLastName {get; set; }
    public string VcEmail {get; set; }
    public string? VcPassword {get; set; }
}
#pragma warning restore CS8618 // Habilitar warning CS8618