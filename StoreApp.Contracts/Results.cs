namespace StoreApp.Contracts;
public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    public List<string> Errors { get; set; }

    private Result(bool isSuccess, T? data, string message, List<string>? errors)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
        Errors = errors;
    }

  
    public static Result<T> Success(T? data, string message = "Success")
        => new Result<T>(true, data, message, null);

    public static Result<T> Failure(string message, List<string>? errors = null)
        => new Result<T>(false, default, message, errors);
}