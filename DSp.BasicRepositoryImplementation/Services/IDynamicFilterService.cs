namespace DSp.BasicRepositoryImplementation
{
    public interface IDynamicFilterService
    {
        IEnumerable<TEntity> ApplyFilters<TEntity>(IEnumerable<TEntity> source, IEnumerable<IQueryFilter<IEnumerable<string>>> filters);
    }
}