using System.Net;

namespace Domain.ApiResponse;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public T? Data { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public ApiResponse(T? data)
    {
        Data = data;
        IsSuccess = true;
        StatusCode = 200;
        Message = null;
    }

    public ApiResponse(HttpStatusCode code, string message)
    {
        IsSuccess = false;
        Data = default;
        StatusCode = (int)code;
        Message = message;
    }
}
