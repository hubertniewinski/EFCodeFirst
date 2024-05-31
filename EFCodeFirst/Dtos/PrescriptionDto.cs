using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Dtos;

public class PrescriptionDto
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public DoctorDto Doctor { get; set; }
    public IEnumerable<MedicamentDto> Medicaments { get; set; }
    
    public PrescriptionDto() { }

    public PrescriptionDto(Prescription prescription)
    {
        IdPrescription = prescription.IdPrescription;
        Date = prescription.Date;
        DueDate = prescription.DueDate;
        Doctor = new DoctorDto(prescription.Doctor);
        Medicaments = prescription.PrescriptionMedicaments.Select(x => new MedicamentDto(x.Medicament, x));
    }
}