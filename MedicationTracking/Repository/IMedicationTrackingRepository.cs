using Ardalis.Specification;

namespace MedicationTracking.Repository;

public interface IMedicationTrackingRepository
{
    Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class;

    Task SaveAsync(CancellationToken cancellationToken = default);

    Task<TEntity> FirstOrDefault<TEntity>(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;

    void Remove<TEntity>(TEntity entity)
        where TEntity : class;

    Task<IReadOnlyCollection<TEntity>> ListAsync<TEntity>(
        ISpecification<TEntity> specification,
        CancellationToken cancellationToken = default
    )
        where TEntity : class;
}
