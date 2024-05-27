namespace Domain.Models.Appointment;

public class Service
{
    public long Id {get; set; }
    public string VcName {get; set; }
    public string VcDescription {get; set; }
    public int? IMinimalPrice {get; set; }
    public int? IMaximalPrice {get; set; }
    public int IRegularPrice {get; set; }
    public decimal DTaxes {get; set; }
    public int? ITime {get; set; }
    public string? VcPhoto {get; set; }
    public string? VcCategory {get; set; }
    public string? VcSubcategory {get; set; }
    public string? VcStatus {get; set; }
}
