namespace Domain.Models.Appointment;

public class Appointment
{
    public long Id {get; set; }
    public long ClientId {get; set; }
    public long ProfessionalId {get; set; }
    public long ServiceId {get; set; }
    public DateTime DtDate {get; set; }
    public TimeSpan TTime { get; set; }
    public Boolean? BIsConfirmed {get; set; }
    public DateTime? DtConfirmedDate {get; set; }
    public Boolean? BIsCanceled {get; set; }
    public DateTime? DtCanceledDate {get; set; }
    public Boolean? BReScheduled {get; set; }
    public DateTime? DtPreviousDate {get; set; }
    public TimeSpan? TPreviousTime { get; set; }
    
}