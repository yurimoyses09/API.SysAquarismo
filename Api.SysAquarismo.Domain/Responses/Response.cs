namespace Api.SysAquarismo.Domain.Responses;

public class Response<TData>
{
    public TData? Data { get; set; }

    public string? Message { get; set; }

    public Response(TData? data, string? message = null)
    {
        Data = data;
        Message = message;
    }
}
