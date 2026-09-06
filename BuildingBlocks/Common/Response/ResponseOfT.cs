namespace BuildingBlocks.Common.Responses;

public class Response<T> : Response
{
    public T? Data { get; set; }
}