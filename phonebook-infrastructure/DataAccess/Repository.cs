using Microsoft.EntityFrameworkCore;
using phonebook_core.Interfaces;
using phonebook_core.Specifications;

namespace phonebook_infrastructure.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PhoneBookContext _context;

        public Repository(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync();
        }

        public IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
