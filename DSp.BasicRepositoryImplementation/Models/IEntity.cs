using System.ComponentModel.DataAnnotations;

namespace DSp.BasicRepositoryImplementation
{
    public interface IEntity<TKey>
    {
        [Key]
        [Required]
        TKey Id { get; set; }
    }
}