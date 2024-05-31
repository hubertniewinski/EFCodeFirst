using EFCodeFirst.Repositories.Models;

namespace EFCodeFirst.Repositories.Abstractions;

public interface IPatientRepository
{
    Task<Patient?> GetAsync(int id, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken);
    Task<Patient> GetDataAsync(int id, CancellationToken cancellationToken);
}