namespace StoreApp.API.ApiHandler;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }

    public bool Status { get; set; }

    public string Message { get; set; } = string.Empty;

    public string? Token { get; set; }

    public T? Result { get; set; }

    public ApiResponse(int statusCode, bool status, string message, T? result = default, string? token = null)
    {
        StatusCode = statusCode;
        Status = status;
        Message = message;
        Result = result;
        Token = token;
    }
}