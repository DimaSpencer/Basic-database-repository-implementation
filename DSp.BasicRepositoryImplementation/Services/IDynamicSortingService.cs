namespace DSp.BasicRepositoryImplementation
{
    public interface IDynamicSortingService
    {
        IEnumerable<TEntity> ApplySorting<TEntity>(IEnumerable<TEntity> source, ISorting sorting);
    }
}