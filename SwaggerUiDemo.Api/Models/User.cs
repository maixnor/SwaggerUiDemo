namespace SwaggerUiDemo.Api.Controllers;

public class User
{
    
    public User() {}
    
    public User(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Username { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;

    public void Deconstruct(out Guid id, out string username, out string email, out string password)
    {
        id = Id;
        username = Username;
        email = Email;
        password = Password;
    }
}