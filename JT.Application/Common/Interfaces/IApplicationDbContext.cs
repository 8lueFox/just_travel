using JT.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JT.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Place> Places { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
