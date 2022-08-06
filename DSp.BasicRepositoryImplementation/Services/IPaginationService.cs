using DSp.BasicRepositoryImplementation.Domain.Models;

namespace DSp.BasicRepositoryImplementation
{
    public interface IPaginationService
    {
        Task<PaginatedList<T>> ToPageAsync<T>(int page, int pageSize, IQueryable<T> source, IEnumerable<T> source);
    }
}