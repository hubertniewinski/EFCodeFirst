namespace EFCodeFirst.Dtos;

public class IssuePrescriptionDto
{
    public int IdDoctor { get; set; }
    public IssuePatientDto Patient { get; set; }
    public IEnumerable<IssueMedicamentDto> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}