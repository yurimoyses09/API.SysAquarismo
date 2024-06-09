namespace Api.SysAquarismo.Domain.Responses;

public class Response<TData>
{
    public TData? data { get; set; }

    public string? message { get; set; }

    public Response(TData? data, string? message = null)
    {
        this.data = data;
        this.message = message;
    }
}
