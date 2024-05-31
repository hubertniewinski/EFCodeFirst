using EFCodeFirst.Dtos.Abstractions;

namespace EFCodeFirst.Dtos;

public class IssuePatientDto : PersonDto
{
    public int IdPatient { get; set; }
    public DateTime Birthdate { get; set; }
}