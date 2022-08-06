using DSp.BasicRepositoryImplementation.Domain.Models;

namespace DSp.BasicRepositoryImplementation.Infrastructure.Implementations
{
    /// <summary>
    /// IPaginationService base implementation.
    /// </summary>
    public class PaginationService : IPaginationService
    {
        public Task<PaginatedList<T>> ToPageAsync<T>(int page, int pageSize, IQueryable<T> source, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}