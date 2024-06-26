namespace Domain.Models.Appointment;

public class Client
{
    public long Id {get; set; }
    public string VcIdentificationNumber {get; set; }
    public string VcPhone {get; set; }
    public string VcFullName {get; set; }
    public string VcEmail {get; set; }
    public Boolean BIsActived {get; set; }

}