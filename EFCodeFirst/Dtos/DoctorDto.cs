using EFCodeFirst.Dtos.Abstractions;
using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Dtos;

public class DoctorDto : PersonDto
{
    public int IdDoctor { get; set; }
    public string Email { get; set; }
    
    public DoctorDto() { }

    public DoctorDto(Doctor doctor) : base(doctor.FirstName, doctor.LastName)
    {
        IdDoctor = doctor.IdDoctor;
        Email = doctor.Email;
    }
}