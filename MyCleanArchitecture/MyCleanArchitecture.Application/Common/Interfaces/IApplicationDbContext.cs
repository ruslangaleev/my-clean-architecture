using Microsoft.EntityFrameworkCore;
using MyCleanArchitecture.Domain.Entities;

namespace MyCleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TagItem> TagItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
