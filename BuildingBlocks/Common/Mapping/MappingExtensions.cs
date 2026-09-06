namespace BuildingBlocks.Common.Mapping;

public static class MappingExtensions
{
    public static IReadOnlyList<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source, Func<TSource, TDestination> mapper)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(mapper);

        return source
            .Select(mapper)
            .ToList();
    }

    public static TDestination? MapIfNotNull<TSource, TDestination>(
        this TSource? source,
        Func<TSource, TDestination> mapper)
        where TSource : class
    {
        ArgumentNullException.ThrowIfNull(mapper);

        return source is null
            ? default
            : mapper(source);
    }
}