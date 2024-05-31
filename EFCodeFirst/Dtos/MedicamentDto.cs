using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Dtos;

public class MedicamentDto
{
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public int? Dose { get; set; }
    public string Description { get; set; }
    
    public MedicamentDto() { }
    
    public MedicamentDto(Medicament medicament, PrescriptionMedicament pm)
    {
        IdMedicament = medicament.IdMedicament;
        Name = medicament.Name;
        Dose = pm.Dose;
        Description = medicament.Description;
    }
}