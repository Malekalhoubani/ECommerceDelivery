namespace BuildingBlocks.Common.Constants;

public static class CommonConstants
{
    public static class Pagination
    {
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 10;
        public const int MaxPageSize = 100;
    }

    public static class Headers
    {
        public const string CorrelationId = "X-Correlation-Id";
        public const string RequestId = "X-Request-Id";
    }

    public static class Claims
    {
        public const string UserId = "sub";
        public const string Role = "role";
    }
}