using EFCodeFirst.Repositories.Abstractions;
using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Repositories;

public class PrescriptionRepository(ApbdContext context) : IPrescriptionRepository
{
    public Task CreateAsync(Prescription prescription, CancellationToken cancellationToken)
    {
        context.Prescriptions.Add(prescription);
        return context.SaveChangesAsync(cancellationToken);
    }
}