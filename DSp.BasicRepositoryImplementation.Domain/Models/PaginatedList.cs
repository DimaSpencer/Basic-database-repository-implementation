namespace DSp.BasicRepositoryImplementation.Domain.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int EndPage { get; set; }
        public int PageSize { get; set; }

        public int ShowingElements { get; set; }
        public int AllElements { get; set; }
    }
}