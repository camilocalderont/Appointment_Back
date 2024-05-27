namespace Domain.Models.Appointment;

public class ProfessionalService
{
    public long ProfessionalId {get; set; }
    public long ServiceId {get; set; }
    public int IRegularPrice {get; set; }
    public decimal DTaxes {get; set; }
}
