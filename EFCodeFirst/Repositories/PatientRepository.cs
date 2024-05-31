using EFCodeFirst.Repositories.Abstractions;
using EFCodeFirst.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Repositories;

public class PatientRepository(ApbdContext context) : IPatientRepository
{
    public Task<Patient?> GetAsync(int id, CancellationToken cancellationToken) =>
        context.Patients
            .FirstOrDefaultAsync(x => x.IdPatient == id, cancellationToken);

    public Task<bool> ExistsAsync(int id, CancellationToken cancellationToken) 
        => context.Patients.AnyAsync(x => x.IdPatient == id, cancellationToken);

    public Task<Patient> GetDataAsync(int id, CancellationToken cancellationToken) =>
        context.Patients
            .Include(x => x.Prescriptions.OrderBy(x=> x.DueDate))
                .ThenInclude(x => x.PrescriptionMedicaments)
                    .ThenInclude(x => x.Medicament)
            .Include(x => x.Prescriptions)
                .ThenInclude(x => x.Doctor)
            .FirstAsync(x => x.IdPatient == id, cancellationToken);
}