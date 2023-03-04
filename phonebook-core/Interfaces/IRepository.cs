using phonebook_core.Specifications;

namespace phonebook_core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
        Task<T> AddAsync(T entity);
    }
}
