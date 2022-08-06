namespace DSp.BasicRepositoryImplementation.Infrastructure.Implementations
{
    public class DynamicSortingService : IDynamicSortingService
    {
        public IEnumerable<TEntity> ApplySorting<TEntity>(IEnumerable<TEntity> source, ISorting sorting)
        {
            throw new NotImplementedException();
        }
    }
}