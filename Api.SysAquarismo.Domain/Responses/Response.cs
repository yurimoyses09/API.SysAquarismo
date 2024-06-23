namespace Api.SysAquarismo.Domain.Responses;

public class Response<TData>(TData? data, string? message = null)
{
    public TData? data { get; set; } = data;

    public string? message { get; set; } = message;
}
