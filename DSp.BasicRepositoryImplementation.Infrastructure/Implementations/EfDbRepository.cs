using DSp.BasicRepositoryImplementation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DSp.BasicRepositoryImplementation.Infrastructure.Implementations
{


    public abstract class EfDbRepository<TEntity, TKey> : IDbRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly DbContext _dbContext;
        private readonly IDynamicFilterService _filterService;
        private readonly IDynamicSortingService _sortingService;
        private readonly IPaginationService _paginationService;

        public EfDbRepository(DbContext dbContet,
            IDynamicFilterService filterService,
            IDynamicSortingService sortingService,
            IPaginationService paginationService)
        {
            _dbContext = dbContet;
            _filterService = filterService;
            _sortingService = sortingService;
            _paginationService = paginationService;
        }

        public virtual async Task<PaginatedList<TEntity>> GetListAsync(int page, int pageSize,
            ISorting sorting, IEnumerable<IQueryFilter<IEnumerable<string>>> filters,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> allEntityes = _dbContext.Set<TEntity>().AsQueryable();

            IQueryable<TEntity> filteredEntityes = _filterService.ApplyFilters(allEntityes, filters).AsQueryable();
            IQueryable<TEntity> sortedEntityes = _sortingService.ApplySorting(filteredEntityes, sorting).AsQueryable();

            return await _paginationService.ToPageAsync(page, pageSize, sortedEntityes, cancellationToken);
        }

        #region BaseOperations

        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
           await _dbContext.SaveChangesAsync(cancellationToken);

        public virtual async Task<TEntity> GetByKeyOrDefaultAsync(TKey key) =>
            await _dbContext.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id.Equals(key));

        public virtual async Task<TEntity> GetByKeyWithoutTrackingAsync(TKey key) =>
            await _dbContext.Set<TEntity>().AsNoTracking()
                .FirstAsync(e => e.Id.Equals(key));

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);

        public virtual async Task<bool> AnyAsync(TKey key) =>
            await _dbContext.Set<TEntity>().AnyAsync(e => e.Id.Equals(key));

        public virtual async Task<int> CountAsync() =>
            await _dbContext.Set<TEntity>().CountAsync();

        public virtual async Task<TEntity> AddAsync(TEntity entity) =>
            (await _dbContext.Set<TEntity>().AddAsync(entity)).Entity;

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);

        public virtual void Update(TEntity entity) =>
            _dbContext.Set<TEntity>().Update(entity);

        public virtual void UpdateRange(IEnumerable<TEntity> entities) =>
            _dbContext.Set<TEntity>().UpdateRange(entities);

        public virtual void Remove(TEntity entity) =>
            _dbContext.Set<TEntity>().Remove(entity);

        public virtual void RemoveRange(IEnumerable<TEntity> entities) =>
            _dbContext.Set<TEntity>().RemoveRange(entities);

        #endregion
    }
}