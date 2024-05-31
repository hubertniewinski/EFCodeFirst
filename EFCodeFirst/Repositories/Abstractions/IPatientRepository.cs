using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Repositories;

public interface IPatientRepository
{
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(Patient patient, CancellationToken cancellationToken);
}