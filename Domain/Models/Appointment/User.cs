namespace Domain.Models.Appointment;

public class User
{
    public Guid Id {get; set; }
    public string VcIdentificationNumber {get; set; }
    public string VcPhone {get; set; }
    public string vcNickName {get; set; }
    public string VcFirstName {get; set; }
    public string VcSecondName {get; set; }
    public string VcFirstLastName {get; set; }
    public string VcSecondLastName {get; set; }
    public string VcEmail {get; set; }

}