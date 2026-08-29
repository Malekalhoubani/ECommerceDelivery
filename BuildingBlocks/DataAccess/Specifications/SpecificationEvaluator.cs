using BuildingBlocks.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Specifications;

public static class SpecificationEvaluator<T>
    where T : BaseEntity
{
    public static IQueryable<T> GetQuery(
        IQueryable<T> inputQuery,
        ISpecification<T> specification)
    {
        var query = inputQuery;

        // Main Criteria
        if (specification.Criteria is not null)
        {
            query = query.Where(specification.Criteria);
        }

        // Additional Expression Filters
        foreach (var filter in specification.Filters)
        {
            query = query.Where(filter);
        }

        // Includes
        query = specification.Includes.Aggregate(
            query,
            (current, include) => current.Include(include));

        // Ascending Sorting
        if (specification.OrderBy is not null)
        {
            query = query.OrderBy(specification.OrderBy);
        }

        // Descending Sorting
        if (specification.OrderByDescending is not null)
        {
            query = query.OrderByDescending(
                specification.OrderByDescending);
        }

        // Pagination
        if (specification.IsPagingEnabled)
        {
            query = query
                .Skip(specification.Skip)
                .Take(specification.Take);
        }

        // Tracking
        if (!specification.IsTrackingEnabled)
        {
            query = query.AsNoTracking();
        }

        return query;
    }
}