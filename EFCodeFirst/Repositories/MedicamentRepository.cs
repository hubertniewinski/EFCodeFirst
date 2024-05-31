using EFCodeFirst.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Repositories;

public class MedicamentRepository(ApbdContext context) : IMedicamentRepository
{
    public async Task<bool> ExistsAsync(IEnumerable<int> ids, CancellationToken cancellationToken)
    {
        var result = await Task.WhenAll(ids.Distinct().Select(id => context.Medicaments.AnyAsync(x => x.IdMedicament == id, cancellationToken)));
        return result.All(x => x);
    }
}