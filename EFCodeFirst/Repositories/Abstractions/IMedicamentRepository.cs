namespace EFCodeFirst.Repositories.Abstractions;

public interface IMedicamentRepository
{
    Task<bool> ExistsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
}