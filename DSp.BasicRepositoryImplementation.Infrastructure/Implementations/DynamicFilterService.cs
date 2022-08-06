namespace DSp.BasicRepositoryImplementation.Infrastructure.Implementations
{
    /// <summary>
    /// DynamicFilterService base implementation
    /// </summary>
    public class DynamicFilterService : IDynamicFilterService
    {
        public IEnumerable<TEntity> ApplyFilters<TEntity>(IEnumerable<TEntity> source, IEnumerable<IQueryFilter<IEnumerable<string>>> filters)
        {
            throw new NotImplementedException();
        }
    }
}