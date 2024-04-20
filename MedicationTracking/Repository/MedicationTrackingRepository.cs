using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Data.Database;
using Microsoft.EntityFrameworkCore;

namespace MedicationTracking.Repository;

public class MedicationTrackingRepository(MedicationTrackingContext medicationTrackingContext)
    : IMedicationTrackingRepository
{
    protected readonly MedicationTrackingContext _medicationTrackingContext =
        medicationTrackingContext;

    public async Task<TEntity> AddAsync<TEntity>(
        TEntity entity,
        CancellationToken cancellationToken = default
    )
        where TEntity : class
    {
        await _medicationTrackingContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await _medicationTrackingContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> FirstOrDefault<TEntity>(ISpecification<TEntity> specification, CancellationToken cancellationToken = default) where TEntity : class
    {
        return (await ApplySepcification(specification).FirstOrDefaultAsync(cancellationToken))!;

    }

    private IQueryable<TEntity> ApplySepcification<TEntity>(ISpecification<TEntity> specification) where TEntity : class
    {
        return SpecificationEvaluator.Default.GetQuery(_medicationTrackingContext.Set<TEntity>().AsQueryable(),
            specification);
    }
}
