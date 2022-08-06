using DynamicExpressions;

namespace DSp.BasicRepositoryImplementation
{
    /// <summary>
    /// For dynamic request filtering
    /// </summary>
    public interface IQueryFilter<TList>
        where TList : IEnumerable<string>
    {
        string Property { get; }
        string Operator { get; }
        TList Values { get; }
    }
}