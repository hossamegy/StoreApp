namespace StoreApp.Contracts.Auth;

public class AuthResult
{
    public string Message { get; set; }
    public bool IsAuthenticated { get; set; } 
    public string Token { get; set; } = string.Empty;
}