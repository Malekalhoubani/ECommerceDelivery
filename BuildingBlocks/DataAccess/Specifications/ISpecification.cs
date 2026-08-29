using System.Linq.Expressions;

namespace DataAccess.Specifications;

public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }

    List<Expression<Func<T, bool>>> Filters { get; }

    List<Expression<Func<T, object>>> Includes { get; }

    Expression<Func<T, object>>? OrderBy { get; }

    Expression<Func<T, object>>? OrderByDescending { get; }

    Expression<Func<T, object>>? Selector { get; }

    int Take { get; }

    int Skip { get; }

    bool IsPagingEnabled { get; }

    bool IsTrackingEnabled { get; }
}