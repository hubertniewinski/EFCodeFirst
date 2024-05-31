using EFCodeFirst.Dtos.Abstractions;
using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Dtos;

public class PatientDto : PersonDto
{
    public int IdPatient { get; set; }
    public DateTime Birthdate { get; set; }
    public IEnumerable<PrescriptionDto> Prescriptions { get; set; }
    
    public PatientDto() { }
    
    public PatientDto(Patient patient) : base(patient.FirstName, patient.LastName)
    {
        IdPatient = patient.IdPatient;
        Birthdate = patient.Birthdate;
        Prescriptions = patient.Prescriptions.Select(x => new PrescriptionDto(x));
    }
}