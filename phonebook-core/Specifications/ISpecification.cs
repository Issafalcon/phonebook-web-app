using System.Linq.Expressions;

namespace phonebook_core.Specifications
{
    public interface ISpecification<T>
    {
        /// <summary>
        /// The predicate expression that is used to satisfy this specification
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }
        /// <summary>
        /// The list of foreign-keyed tables to include in the final result
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }
        /// <summary>
        /// The order clause (ascending)
        /// </summary>

        Expression<Func<T, object>> OrderBy { get; }
        /// <summary>
        /// The order clause (descending)
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }
    }
}
