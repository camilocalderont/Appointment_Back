namespace Domain.Models.Appointment;

public class Professional
{
    public long Id {get; set; }
    public string VcFirstName {get; set; }
    public string? VcSecondName {get; set; }
    public string VcFirstLastName {get; set; }
    public string? VcSecondLastName {get; set; }
    public string VcEmail {get; set; }
    public string VcPhone {get; set; }
    public string VcIdentificationNumber {get; set; }
    public string? VcLicenseNumber {get; set; }
    public int IYearsOfExperience {get; set; }
    public string? VcPhoto {get; set; }
    public string? VcProfession {get; set; }
    public string? VcSpecialization {get; set; }

}