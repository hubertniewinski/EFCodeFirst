namespace EFCodeFirst.Repositories.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public int IdPatient { get; set; }
    public virtual Patient Patient { get; set; }
    public int IdDoctor { get; set; }
    public virtual Doctor Doctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public virtual IEnumerable<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}