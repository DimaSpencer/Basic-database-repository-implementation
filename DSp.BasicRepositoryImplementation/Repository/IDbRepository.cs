using DSp.BasicRepositoryImplementation.Domain.Models;

namespace DSp.BasicRepositoryImplementation
{
    public interface IDbRepository<TEntity, TKey>
        where TEntity : IEntity<TKey>
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<PaginatedList<TEntity>> GetListAsync(int page, int pageSize,
            ISorting sorting, IEnumerable<IQueryFilter<IEnumerable<string>>> filters, 
            CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<TEntity> GetByKeyOrDefaultAsync(TKey key);
        Task<TEntity> GetByKeyWithoutTrackingAsync(TKey key);

        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        
        Task<bool> AnyAsync(TKey key);
        Task<int> CountAsync();

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}