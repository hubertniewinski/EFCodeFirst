namespace EFCodeFirst.Repositories.Models;

public class Patient : Person
{
    public int IdPatient { get; set; }
    public DateTime Birthdate { get; set; }
    public virtual IEnumerable<Prescription> Prescriptions { get; set; }
}