namespace StoreApp.Contracts.Auth;

public class AuthSignUpResponse1
{
    public string Email { get; set; } = string.Empty;
}

public class AuthSignInResponse1
{
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}