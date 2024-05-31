namespace EFCodeFirst.Repositories;

public interface IMedicamentRepository
{
    Task<bool> ExistsAsync(IEnumerable<int> ids, CancellationToken cancellationToken);
}