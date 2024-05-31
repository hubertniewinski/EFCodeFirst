using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Repositories.Abstractions;

public interface IPrescriptionRepository
{
    Task CreateAsync(Prescription prescription, CancellationToken cancellationToken);
}