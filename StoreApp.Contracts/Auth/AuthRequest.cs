namespace StoreApp.Contracts.Auth;

public class RegisterRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
    
    public string ProfileImg { get; set; } = string.Empty;
    
    public string City { get;  set; }
    public string Street { get;  set; }
    public string Building { get;  set; }= string.Empty;
    public string PostalCode { get; set; } = string.Empty;
}

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}